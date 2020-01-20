using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHighlight : MonoBehaviour
{
    [SerializeField]
    private Material _hoverHighlightMaterial;

    [SerializeField]
    private Material _selectHighlightMaterial;

    private Renderer _rend;

    void Start()
    {
        _rend = GetComponent<Renderer>();
    }

    public void DisableSelectHighlight()
    {
        RemoveMat(_selectHighlightMaterial);
    }

    public void DisableHoverHighlight()
    {
        RemoveMat(_hoverHighlightMaterial);   
    }

    public void EnableSelectHighlight()
    {
        AddMat(_selectHighlightMaterial);
    }

    public void EnableHoverHighlight()
    {
        AddMat(_hoverHighlightMaterial);
    }

    public void AddMat(Material mat)
    {
        Material[] materials = new Material[_rend.sharedMaterials.Length + 1];
        Debug.Log(_rend.sharedMaterials.Length);
        for(int i = 0; i < _rend.sharedMaterials.Length; i++)
        {
            materials[i] = _rend.sharedMaterials[i];
        }

        materials[_rend.sharedMaterials.Length] = mat;
        _rend.sharedMaterials = materials;
    }

    private void RemoveMat(Material mat)
    {
        int matIndex = FindIndexOfMat(mat);
        Material[] newMats = new Material[_rend.sharedMaterials.Length-1];

        int offset = 0;
        if (matIndex != -1)
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
