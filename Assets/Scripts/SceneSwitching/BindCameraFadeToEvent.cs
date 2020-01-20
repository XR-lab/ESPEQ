using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindCameraFadeToEvent : MonoBehaviour
{
    [SerializeField]
    private FadeScript _fadeScript;

    [SerializeField]
    private SceneSwitcherEventEnum _event;

    private void BindEvent()
    {
        if (!_fadeScript)
        {
            _fadeScript = gameObject.GetComponent<FadeScript>();
        }
        switch (_event)
        {
            case SceneSwitcherEventEnum.beforeDestroy:
                SceneSwitcher.Instance.BeforeDestroy.AddListener(_fadeScript.ToggleFade);
                break;
            case SceneSwitcherEventEnum.onLoad:
                SceneSwitcher.Instance.OnLoad.AddListener(_fadeScript.ToggleFade);
                break;
            case SceneSwitcherEventEnum.onLoaded:
                SceneSwitcher.Instance.OnLoaded.AddListener(_fadeScript.ToggleFade);
                break;
        }
        _fadeScript.OnFadeIn.AddListener(SceneSwitcher.Instance.Callback);
        gameObject.GetComponent<BindCameraFadeToEvent>().enabled = false;
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("LevelLoading"))
        {
            BindEvent();
        }
    }
}
