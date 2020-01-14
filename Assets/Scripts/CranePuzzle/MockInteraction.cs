using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MockInteraction : MonoBehaviour
{
    [SerializeField] private UnityEvent ButtonPressed;

    void Update() {
        if (Input.GetKey(KeyCode.Return)) {
            ButtonPressed?.Invoke();
        }
    }
}
