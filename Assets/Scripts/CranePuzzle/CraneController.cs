using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneController : MonoBehaviour {

    [SerializeField] private Transform _target;
    [SerializeField] private float _distanceToTravel = 1;
    [SerializeField] private SetAudio _setAudio;

    private float _targetPos;
    private float _startPos;
    private float _pos;

    private bool _move = false;

    public int clip;
    
    void Start()
    {
        _startPos = _target.localPosition.y;
        _pos = _startPos;
        _targetPos = _startPos + _distanceToTravel;
    }

    public void MoveUp() {
        _move = true;
    }

    void Update()
    {
        if (_move && _pos < _targetPos)
        {
            _pos += .01f;
            _target.localPosition = new Vector3(_target.localPosition.x, _pos, _target.localPosition.z);
        }
        else if(_pos >= _targetPos)
        {
            _setAudio.AudioSetter(clip);
        }
    }
}
