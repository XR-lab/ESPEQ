using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleWalkable : MonoBehaviour
{
    public void Toggle()
    {
        GetComponent<Collider>().enabled = !GetComponent<Collider>().enabled;
        GetComponent<ParticleSystem>().Stop();
    }
}
