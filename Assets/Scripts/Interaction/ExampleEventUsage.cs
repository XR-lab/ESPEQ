using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleEventUsage : MonoBehaviour
{
    public void TestNearDetect(DetectionData data)
    {
        Debug.Log("Near: " + data.Collider.name + ", " + gameObject.tag);
    }

    public void TestHitDetect(DetectionData data)
    {
        Debug.Log("Hit: " + data.Collider + ", " + gameObject.tag);
    }

    public void TestWithNoArgs()
    {
        Debug.Log("Test with no args");
    }
}
