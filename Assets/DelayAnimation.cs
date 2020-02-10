using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayAnimation : MonoBehaviour
{
    [SerializeField]
    private float _delay = 5;
    void Start()
    {
        Invoke("StartAnimation", _delay);
    }

    void StartAnimation()
    {
        GetComponent<Animator>().enabled = true;
        print("hi");
    }
}
