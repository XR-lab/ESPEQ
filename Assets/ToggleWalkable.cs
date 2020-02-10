using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleWalkable : MonoBehaviour
{
    private void Toggle()
    {
        GetComponent<Collider>().enabled = !GetComponent<Collider>().enabled;
    }
}
