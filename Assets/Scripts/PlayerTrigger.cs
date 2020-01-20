using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _OnTriggerEnter;
    [SerializeField] private string _player;

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.transform.root.name == _player)
        {
            _OnTriggerEnter?.Invoke();
        }
    }
}
