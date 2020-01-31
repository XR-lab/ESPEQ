using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;



public class OVRInputManager : MonoBehaviour
{
    public static OVRInputManager instance;

    [Header("Controller")]

    [SerializeField]
    private OVRInput.Controller _leftController;
    [SerializeField]
    private OVRInput.Controller _rightController;

    [Header("Standard Input")]

    [SerializeField]
    private OVRInput.Axis2D _rotate;
    [SerializeField]
    private OVRInput.Axis1D[] _interact;
    [SerializeField]
    private OVRInput.Button _teleport;
    [SerializeField]
    private OVRInput.Button _pause;

    [Header("Raw Inputs")]

    //Raw input enums

    [SerializeField]
    private OVRInput.RawAxis2D _rotateRaw;
    [SerializeField]
    private OVRInput.RawAxis1D[] _interactRaw;
    [SerializeField]
    private OVRInput.RawButton[] _teleportRaw;
    [SerializeField]
    private OVRInput.RawTouch[] _teleportRawTouch;
    [SerializeField]
    private OVRInput.RawButton _pauseRaw;

    private void Start()
    {
        if (null != instance)
        {
            Destroy(this);
        }
        else instance = this;
    }

    //Miscellaneous controller info

    public Vector3 GetPositionLeftController()
    {
        return OVRInput.GetLocalControllerPosition(_leftController);
    }

    public Quaternion GetRotationLeftController()
    {
        return OVRInput.GetLocalControllerRotation(_leftController);
    }

    public Vector3 GetVelocityLeftController()
    {
        return OVRInput.GetLocalControllerVelocity(_leftController);
    }

    public Vector3 GetPositionRightController()
    {
        return OVRInput.GetLocalControllerPosition(_rightController);
    }

    public Quaternion GetRotationRightController()
    {
        return OVRInput.GetLocalControllerRotation(_rightController);
    }

    public Vector3 GetVelocityRightController()
    {
        return OVRInput.GetLocalControllerVelocity(_rightController);
    }

    //These functions return the input values.

    public Vector2 GetRotate()
    {
        return OVRInput.Get(_rotate);
    }
    public float[] GetInteract()
    {
        int length = _interact.Length;
        if (length == 0) {
            return null;
        }
        float[] value = new float[length];
        for (int i = 0; i < length; i++) {
            value[i] = OVRInput.Get(_interact[i]);
        }
        return value;
    }

    public bool GetTeleportDown()
    {
        return OVRInput.GetDown(_teleport);
    }

    public bool GetTeleport()
    {
        return OVRInput.Get(_teleport);
    }

    public bool GetTeleportRelease()
    {
        return OVRInput.GetUp(_teleport);
    }
    
    //These functions return the raw input values.

    public Vector2 GetRotateRaw()
    {
        return OVRInput.Get(_rotateRaw);
    }

    public float[] GetInteractRaw()
    {
        int length = _interactRaw.Length;
        if (length == 0) {
            return null;
        }
        float[] value = new float[length];
        for (int i = 0; i < length; i++) {
            value[i] = OVRInput.Get(_interactRaw[i]);
        }
        return value;
    }

    public bool[] GetTeleportDownRaw()
    {
        int length = _teleportRaw.Length;
        if (length == 0) {
            return null;
        }
        bool[] value = new bool[length];
        for (int i = 0; i < length; i++) {
            value[i] = OVRInput.GetDown(_teleportRaw[i]);
        }
        return value;
    }

    public bool[] GetTeleportRaw()
    {
        int length = _teleportRaw.Length;
        if (length == 0) {
            return null;
        }
        bool[] value = new bool[length];
        for (int i = 0; i < length; i++) {
            value[i] = OVRInput.Get(_teleportRaw[i]);
        }
        return value;
    }

    public bool[] GetTeleportReleaseRaw()
    {
        int length = _teleportRaw.Length;
        if (length == 0) {
            return null;
        }
        bool[] value = new bool[length];
        for (int i = 0; i < length; i++) {
            value[i] = OVRInput.GetUp(_teleportRaw[i]);
        }
        return value;
    }

    public OVRInput.RawButton[] GetTeleportRawButtons()
        {
        return _teleportRaw;
    }

    public OVRInput.RawTouch[] GetTeleportRawTouches()
        {
        return _teleportRawTouch;
    }

    public OVRInput.RawAxis1D[] GetInteractRawButtons() {
        return _interactRaw;
    }
}
