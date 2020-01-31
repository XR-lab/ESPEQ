using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputInteract : MonoBehaviour
{
    private bool _input = false;
    
    void Update()
    {
        if (OVRInputManager.instance.GetInteract()[0] == 1 && _input == false)
        {
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
