using UnityEngine;

public class OnGrabAudio : MonoBehaviour
{
    private OVRGrabbable _grabbable;
    private SetAudio _setAudio;
    private bool _happend;

    public int clip;
    
    void Start()
    {
        _setAudio = GameObject.FindWithTag("GameManager").GetComponent<SetAudio>();
        _grabbable = this.GetComponent<OVRGrabbable>();
    }

    void Update()
    {
        if (_grabbable.isGrabbed && !_happend)
        {
            _happend = true;
            _setAudio.AudioSetter(clip);
        }
    }
}
