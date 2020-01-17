using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

/// <summary>
/// Modified version of the TeleportInputHandlerTouch script made for the .
/// When this component is in use, the player will be able to aim and trigger teleport behavior using Oculus Touch controller buttons assigned to the Teleport action of the InputManager script.
/// </summary>
public class TeleportInputHandlerCustom : TeleportInputHandlerHMD
{
    public Transform LeftHand;
    public Transform RightHand;

    private OVRInput.RawButton[] _rawButtons;
    private OVRInput.RawTouch[] _rawTouch;

    private bool _initialized;

    /// <summary>
    /// Which controller is being used for aiming.
    /// </summary>
    [Tooltip("Select the controller to be used for aiming. Supports LTouch, RTouch, or Touch for either.")]
    public OVRInput.Controller AimingController;

    private OVRInput.Controller _initiatingController;

    /// <summary>
    /// The button to use for triggering aim and teleport when InputMode==CapacitiveButtonForAimAndTeleport
    /// </summary>
    private OVRInput.RawButton[] _capacitiveAimAndTeleportButtons;

    private OVRInput.RawButton _currentCapacitiveButton;
    private OVRInput.RawTouch _currentAimTouch;

    /// <summary>
    /// Based on the input mode, controller state, and current intention of the teleport controller, return the apparent intention of the user.
    /// </summary>
    /// <returns></returns>
    public override LocomotionTeleport.TeleportIntentions GetIntention() {
        if (!isActiveAndEnabled || !_initialized) {
            return global::LocomotionTeleport.TeleportIntentions.None;
        }

        OVRInput.RawButton teleportButton = _currentCapacitiveButton;

        if (LocomotionTeleport.CurrentIntention == LocomotionTeleport.TeleportIntentions.Aim) {
            // If the user has actually pressed the teleport button, enter the preteleport state.
            if (OVRInput.GetDown(teleportButton)) {
                // If the user has released the button, enter the PreTeleport state unless FastTeleport is enabled, 
                // in which case enter the Teleport state.
                return FastTeleport ? LocomotionTeleport.TeleportIntentions.Teleport : LocomotionTeleport.TeleportIntentions.PreTeleport;
            }
        }

        // If the user is already in the PreTeleport state, the intention will be to either remain in this state or switch to Teleport
        if (LocomotionTeleport.CurrentIntention == LocomotionTeleport.TeleportIntentions.PreTeleport) {
            // If they released the button, switch to Teleport.
            if (FastTeleport || OVRInput.GetUp(teleportButton)) {
                _currentAimTouch = OVRInput.RawTouch.None;
                _currentCapacitiveButton = OVRInput.RawButton.None;
                // Button released, enter the Teleport state.
                return LocomotionTeleport.TeleportIntentions.Teleport;
            }
            // Button still down, remain in PreTeleport so they can orient the destination if an orientation handler supports it.
            return LocomotionTeleport.TeleportIntentions.PreTeleport;
        }

        // If it made it this far, then we need to determine if the user intends to be aiming with the capacitive touch.
        // The first check is if cap touch has been triggered. 
        if (GetCurrentRawTouchDown(_rawTouch)) {
            return LocomotionTeleport.TeleportIntentions.Aim;
        }

        if (LocomotionTeleport.CurrentIntention == LocomotionTeleport.TeleportIntentions.Aim) {
            if (!OVRInput.GetUp(_currentAimTouch)) {
                return LocomotionTeleport.TeleportIntentions.Aim;
            }
        }
        
        return LocomotionTeleport.TeleportIntentions.None;
    }

    void Start() {
        Invoke("GetButtonMapping", 0.1f);
    }

    void GetButtonMapping() {
        _rawButtons = OVRInputManager.instance.GetTeleportRawButtons();
        _capacitiveAimAndTeleportButtons = _rawButtons;
        _rawTouch = OVRInputManager.instance.GetTeleportRawTouches();
        _initialized = true;
    }

    private bool GetCurrentRawTouchDown(OVRInput.RawTouch[] touches) {
        bool touching = false;
        int length = touches.Length;
        for (int i = 0; i < length; i++) {
            if (OVRInput.GetDown(touches[i])) {
                _currentAimTouch = touches[i];
                _currentCapacitiveButton = _capacitiveAimAndTeleportButtons[i];
                touching = true;
            }
        }
        if (_currentAimTouch == OVRInput.RawTouch.X || _currentAimTouch == OVRInput.RawTouch.Y) {
            _initiatingController = OVRInput.Controller.LTouch;
        }
        else {
            _initiatingController = OVRInput.Controller.RTouch;
        }
        return touching;
    }

    public override void GetAimData(out Ray aimRay) {
        OVRInput.Controller sourceController = AimingController;
        if (sourceController == OVRInput.Controller.Touch) {
            sourceController = _initiatingController;
        }
        Transform t = (sourceController == OVRInput.Controller.LTouch) ? LeftHand : RightHand;
        aimRay = new Ray(t.position, t.forward);
    }
}
