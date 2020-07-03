﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputInteract : MonoBehaviour
{
    private bool _input = false;
    [SerializeField] private SetAudio _setAudio;

    public bool audio;
    public int target;
    
    void Update()
    {
        if (OVRInputManager.instance.GetInteract()[0] == 1 && _input == false)
        {
            if(audio)
                _setAudio.AudioSetter(target);
            
            _input = true;
        }
        else if(OVRInputManager.instance.GetInteract()[0] == 0)
        {
            _input = false;
        }
    }

    public bool GetInput()
    {
        return _input;
    }
}
