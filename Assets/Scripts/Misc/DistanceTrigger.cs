using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _target1, _target2;
    private SetAudio _setAudio;
    
    public float triggerDistance;
    public int clip;
    
    private void Start()
    {
        _setAudio = GameObject.FindWithTag("GameManager").GetComponent<SetAudio>();
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(_target1.transform.position, _target2.transform.position) <= triggerDistance)
        {
            _setAudio.AudioSetter(clip);
        }
    }
}
