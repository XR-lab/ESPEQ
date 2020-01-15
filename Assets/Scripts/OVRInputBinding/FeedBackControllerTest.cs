using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FeedBackController : MonoBehaviour
{
    [SerializeField]
    private Transform _joyStickResponse;
    private Vector3 _originPosition;

    // Start is called before the first frame update
    void Start()
    {
        _originPosition = _joyStickResponse.position;
    }

    public void MoveBlock(Vector2 output)
    {
        Vector3 newPosition = _originPosition + new Vector3(output.x, output.y, 0) * 3;

        _joyStickResponse.transform.position = newPosition;
    }

    public void RotateBlock(Quaternion output)
    {
        _joyStickResponse.transform.rotation = output;
    }

    private void Update()
    {
        MoveBlock(OVRInputManager.instance.GetRotate());
        RotateBlock(OVRInputManager.instance.GetRotationRightController());
    }
}
