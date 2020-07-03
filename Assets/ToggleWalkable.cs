using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleWalkable : MonoBehaviour
{
    private SetAudio _setAudio;

    public int clip;

    private void Start()
    {
        _setAudio = GameObject.FindWithTag("GameManager").GetComponent<SetAudio>();
    }

    private void OnCollisionEnter(Collision other)
    {
        _setAudio.AudioSetter(clip);
    }

    public void Toggle()
    {
        GetComponent<Collider>().enabled = !GetComponent<Collider>().enabled;
        GetComponent<ParticleSystem>().Stop();
    }
}
