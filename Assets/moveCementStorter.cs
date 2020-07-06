using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCementStorter : MonoBehaviour
{
    public GameObject cementBlock;

    public float limit1;
    public float limit2;
    private void OnTriggerStay(Collider coll)
    {
        if (coll.gameObject.CompareTag("Hand") && CompareTag("LeftButton")  && cementBlock.transform.position.x >= limit1 )
        {
            cementBlock.transform.Translate(Vector3.left * -0.01f);
        }
        if (coll.gameObject.CompareTag("Hand") && CompareTag("RightButton") && cementBlock.transform.position.x >= limit2 )
        {
            cementBlock.transform.Translate(Vector3.left * 0.01f);
        }
    }
}


