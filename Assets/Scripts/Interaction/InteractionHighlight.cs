using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHighlight : MonoBehaviour
{
    [SerializeField]
    private Material _hoverHighlightMaterial;

    [SerializeField]
    private Material _selectHighlightMaterial;

    [SerializeField]
    private Material _triggerHighlightMaterial;

    [SerializeField]
    private bool _triggerAble;

    [SerializeField]
    private float _thresholdTrigger = 0.9f;

    public enum Highlight { None, Hover, Selected, Triggered};
    private enum Situation { Enter, Stay, Exit};

    private Highlight _highlightState = Highlight.None;

    private List<GameObject> _objectsInHover = new List<GameObject>();
    private List<GameObject> _objectsInSelect = new List<GameObject>();
    private List<GameObject> _objectsInTrigger = new List<GameObject>();

    private Renderer _rend;

    void Start()
    {
        _rend = GetComponent<Renderer>();
    }

    private void StateUpdate()
    {
        switch (_highlightState)
        {
            case Highlight.None:
                if (_objectsInHover.Count >= 1)
                {
                    StateAction(Situation.Exit);
                    _highlightState = Highlight.Hover;
                    StateAction(Situation.Enter);
                    break;
                }
                StateAction(Situation.Stay);
                break;
            case Highlight.Hover:
                if (_objectsInHover.Count == 0)
                {
                    StateAction(Situation.Exit);
                    _highlightState = Highlight.None;
                    break;
                }
                if (_objectsInSelect.Count >= 1)
                {
                    StateAction(Situation.Exit);
                    _highlightState = Highlight.Selected;
                    StateAction(Situation.Enter);
                    break;
                }
                StateAction(Situation.Stay);
                break;
            case Highlight.Selected:
                if (_objectsInSelect.Count == 0)
                {
                    StateAction(Situation.Exit);
                    _highlightState = Highlight.Hover;
                    StateAction(Situation.Enter);
                    break;
                }
                bool Triggered = false;
                foreach (float Axis1D in OVRInputManager.instance.GetInteract())
                {
                    if (Axis1D >= _thresholdTrigger)
                    {
                        Triggered = true;
                    }
                }
                if (Triggered)
                {
                    StateAction(Situation.Exit);
                    _highlightState = Highlight.Triggered;
                    StateAction(Situation.Enter);
                    break;
                }
                
                StateAction(Situation.Stay);
                break;
            case Highlight.Triggered:
                bool Untriggered = false;
                foreach (float Axis1D in OVRInputManager.instance.GetInteract())
                {
                    if (Axis1D < _thresholdTrigger)
                    {
                        Untriggered = true;
                    }
                }
                if (Untriggered)
                {
                    StateAction(Situation.Exit);
                    _highlightState = Highlight.Selected;
                    StateAction(Situation.Enter);
                    break;
                }  
                StateAction(Situation.Stay);
                break;
        }
    }

    private void StateAction(Situation state)
    {
        switch (_highlightState)
        {
            case Highlight.Hover:
                switch (state)
                {
                    case Situation.Exit:
                        RemoveMat(_hoverHighlightMaterial);
                        break;
                    case Situation.Enter:
                        AddMat(_hoverHighlightMaterial);
                        break;
                }
                break;

            case Highlight.Selected:
                switch (state)
                {
                    case Situation.Exit:
                        RemoveMat(_selectHighlightMaterial);
                        break;
                    case Situation.Enter:
                        AddMat(_selectHighlightMaterial);
                        break;
                }
                break;

            case Highlight.Triggered:
                switch (state)
                {
                    case Situation.Enter:
                        AddMat(_triggerHighlightMaterial);
                        break;
                    case Situation.Exit:
                        RemoveMat(_triggerHighlightMaterial);
                        break;
                }
                break;
        }
        Debug.LogError(_highlightState);
    }

    public void HandExitSelectHighlight(DetectionData data)
    {
        _objectsInSelect.Remove(data.Collider.gameObject);
        StateUpdate();
    }

    public void HandExitHoverHighlight(DetectionData data)
    {
        _objectsInHover.Remove(data.Collider.gameObject);
        StateUpdate();
    }

    public void HandEnterSelectHighlight(DetectionData data)
    {
        _objectsInSelect.Add(data.Collider.gameObject);
        StateUpdate();
    }

    public void HandEnterHoverHighlight(DetectionData data)
    {
        _objectsInHover.Add(data.Collider.gameObject);
        StateUpdate();
    }

    public void IsTriggered()
    {
        if (_triggerAble)
        {
            StateUpdate();
        }
    }
    private void AddMat(Material mat)
    {
        int matExists = FindIndexOfMat(mat);
        if (mat != null && matExists == -1)
        {
            Material[] materials = new Material[_rend.sharedMaterials.Length + 1];
            for (int i = 0; i < _rend.sharedMaterials.Length; i++)
            {
                materials[i] = _rend.sharedMaterials[i];
            }

            materials[_rend.sharedMaterials.Length] = mat;
            _rend.sharedMaterials = materials;
        }
    }

    private void RemoveMat(Material mat)
    {
        int matIndex = FindIndexOfMat(mat);
        Material[] newMats = new Material[_rend.sharedMaterials.Length-1];

        int offset = 0;
        if (matIndex != -1 && mat != null)
        {
            for (int i = 0; i < _rend.sharedMaterials.Length; i++)
            {
                if (i != matIndex)
                {
                    newMats[i - offset] = _rend.sharedMaterials[i];
                }
                else
                {
                    offset++;
                }
            }
            _rend.sharedMaterials = newMats;
        }
    }

    private int FindIndexOfMat(Material mat)
    {
        for (int i = 0; i < _rend.sharedMaterials.Length; i++)
        {
            if (_rend.sharedMaterials[i] == mat)
            {
                Debug.Log(mat.name);
                return i;
            }
        }
        Debug.LogError("Couldn't find the material");
        return -1;
    }
}
