using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableConstraints : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    private Rigidbody _rb;
    private SetAudio _setAudio;
    private int _clip = 1;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _setAudio = GameObject.FindWithTag("GameManager").GetComponent<SetAudio>();
    }

    private void OnCollisionEnter(Collision _col)
    {
        if (_col.gameObject == _target)
        {
            if (_rb != null)
            {
                _rb.constraints = RigidbodyConstraints.None;
                _setAudio.AudioSetter(_clip);
            }
        }
    }
}
