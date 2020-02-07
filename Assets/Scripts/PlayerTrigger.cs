using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _OnTriggerEnter;
    private void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.CompareTag("Player"))
        {
            _OnTriggerEnter?.Invoke();
        }
    }
}
