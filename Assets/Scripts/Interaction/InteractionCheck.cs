using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionCheck : MonoBehaviour {

    public UnityEvent InvokeAction;

    private OVRInput.RawAxis1D[] _rawInteractButtons;

    private bool _initialized;
    private bool _canInvoke = true;

    private void Start() {
        Invoke("GetButtonMapping", 0.1f);
    }

    private void GetButtonMapping() {
        _rawInteractButtons = OVRInputManager.instance.GetInteractRawButtons();
        _initialized = true;
    }

    public void SingleInvoke() {
        if (_canInvoke && CheckInput()) {
            InvokeAction?.Invoke();
        }
    }

    public void ContinuousInvoke() {
        if (CheckInput()) {
            InvokeAction?.Invoke();
        }
    }

    private bool CheckInput() {
        int length = _rawInteractButtons.Length;
        if (length == 0) {
            Debug.LogError("No Buttons have been assigned for interaction");
            return false;
        }
        for (int i = 0; i < length; i++) {
            if (OVRInput.Get(_rawInteractButtons[i]) >= 0.75f) {
                return true;
            }
        }
        return false;
    }

    public void ReEnableInvoke() {
        _canInvoke = true;
    }

}
