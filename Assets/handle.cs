using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handle : MonoBehaviour
{
    private void OnTriggerStay(Collider _coll)
    {
        if (_coll.gameObject.CompareTag("Hand") && OVRInputManager.instance.GetInteract()[0] == 1 && transform.localPosition.z > -.5f)
        {
            transform.localPosition -= Vector3.forward * OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTrackedRemote).sqrMagnitude;
        }

        if(transform.localPosition.z <= -.45f)
        {
            GetComponent<CraneController>().MoveUp();
        }
    }
}
