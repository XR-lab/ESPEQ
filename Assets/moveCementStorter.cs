using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCementStorter : MonoBehaviour
{
    public GameObject cementBlock;
    //public ParticleSystem cementParticle;
    private void OnTriggerStay(Collider _coll)
    {
        if (_coll.gameObject.CompareTag("Hand") && CompareTag("LeftButton"))
        {
            cementBlock.transform.Translate(Vector3.back * 0.1f);
        }
        if (_coll.gameObject.CompareTag("Hand") && CompareTag("RightButton"))
        {
            cementBlock.transform.Translate(Vector3.forward * 0.1f);
        }
    
       
    }
}


