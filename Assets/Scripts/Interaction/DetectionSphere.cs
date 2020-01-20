using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class DetectionSphere : MonoBehaviour
{
    [Serializable]
    public class DetectionEvent : UnityEvent<DetectionData>
    {
    }

    [SerializeField]
    private List<string> _detectionTags;

    [SerializeField]
    private DetectionEvent _onDetectionEnter;

    [SerializeField]
    private DetectionEvent _onDetection;

    [SerializeField]
    private DetectionEvent _onDetectionExit;

    private bool _isActive = false;

    private Collider _col;

    private void Awake()
    {
        _col = GetComponent<Collider>();
        if (!_col)
        {
            _col = gameObject.AddComponent<SphereCollider>();
        }
        _col.isTrigger = true;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;
    }

    private void ValidateTags(Collider other, DetectionEvent detectionEvent, bool setActive)
    {
        if (_detectionTags.Count != 0)
        { 
            foreach (string tag in _detectionTags)
            {
                if (other.gameObject.tag == tag)
                {
                    _isActive = setActive;

                    DetectionData data = new DetectionData(other, _col);
                    detectionEvent?.Invoke(data);
                }
            }
        } else Debug.LogError("No tags were listed to check on.");

    }

    private void ValidateTags(Collider other, DetectionEvent detectionEvent)
    {
        if (_detectionTags.Count != 0)
        {
            foreach (string tag in _detectionTags)
            {
                if (other.gameObject.tag == tag)
                {
                    DetectionData data = new DetectionData(other, _col);
                    detectionEvent?.Invoke(data);
                }
            }
        }
        else Debug.LogError("No tags were listed to check on.");
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Collider ownCollider = GetComponent<Collider>();
        ValidateTags(other,_onDetectionEnter,true);
    }

    private void OnTriggerStay(Collider other)
    {
        ValidateTags(other, _onDetection);
    }

    private void OnTriggerExit(Collider other)
    {
        ValidateTags(other,_onDetectionExit,false);
    }
}

public class DetectionData : EventArgs
{
    public readonly Collider Collider;
    public readonly Collider InteractableCollider;

    public DetectionData(Collider collider, Collider interactableCollider)
    {
        Collider = collider;
        InteractableCollider = interactableCollider;
    }
}