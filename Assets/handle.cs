using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handle : MonoBehaviour
{
    private void OnTrigger()
    {
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.Touch) < .5f)
            return;

        this.transform.position = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
    }
    
}
