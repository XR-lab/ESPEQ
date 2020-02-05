using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableConstraints : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision _col)
    {
        if (_col.gameObject == _target)
        {
            if (_rb != null)
            {
                _rb.constraints = RigidbodyConstraints.None;
            }
        }
    }
}
