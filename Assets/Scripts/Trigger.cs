using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] private UnityEvent OnTrigger;
    [SerializeField] private new string tag;
    private void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.CompareTag(tag))
        {
            OnTrigger?.Invoke();
        }
    }
}
