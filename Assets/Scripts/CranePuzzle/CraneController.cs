using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneController : MonoBehaviour {

    [SerializeField] private Transform _wall;

    [SerializeField] private float _moveSpeed = 0;
    [SerializeField] private float _maxMoveSpeed;
    [SerializeField] private float _acceleration;
    [SerializeField] private float _distance = 0;
    [SerializeField] private float _maxDistance;
    private bool _isMovingUp;

    public void MoveUp() {
        _isMovingUp = true;
        if (_distance < _maxDistance) {
            if (_moveSpeed < _maxMoveSpeed) {
                _moveSpeed += _acceleration;
            }
        }
    }

    void Update() {
        if (_moveSpeed == 0) {
            return;
        }
        if (_distance >= _maxDistance || !_isMovingUp) {
            if (_moveSpeed > 0) {
                _moveSpeed -= _acceleration;
            }
        }
        if (_moveSpeed < 0) {
            _moveSpeed = 0;
        }
        _wall.Translate(Vector3.up * _moveSpeed);
        _distance += _moveSpeed;
        _isMovingUp = false;
    }
}
