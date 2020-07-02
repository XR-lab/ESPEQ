using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCementStorter : MonoBehaviour
{
    public HingeJoint hinge;
    public Collider cement;

    void Update()
    {
        if (hinge.limits.min <= -60)
        {
            cement.enabled = false;
        }
    }
}
