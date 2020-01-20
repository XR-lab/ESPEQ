using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindOVRFadeToEvent : MonoBehaviour
{
    /// <summary>
    /// Binds the ovr fadeout function to a selected event
    /// </summary>

    [SerializeField]
    private OVRScreenFade _fadeScript; // The fade component that will be needed to bind it to the event

    [SerializeField]
    private SceneSwitcherEventEnum _event; // Event enumerator to determine where to bind the event

    // Start is called before the first frame update
    void Start()
    {
        if (!_fadeScript)
        {
            _fadeScript = gameObject.GetComponent<OVRScreenFade>();
        }
        switch (_event)
        {
            case SceneSwitcherEventEnum.beforeDestroy:
                SceneSwitcher.Instance.BeforeDestroy.AddListener(_fadeScript.FadeOut);
                break;
            case SceneSwitcherEventEnum.onLoad:
                SceneSwitcher.Instance.OnLoad.AddListener(_fadeScript.FadeOut);
                break;
            case SceneSwitcherEventEnum.onLoaded:
                SceneSwitcher.Instance.OnLoaded.AddListener(_fadeScript.FadeOut);
                break;
        }
    }
}
