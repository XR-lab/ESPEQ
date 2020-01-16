using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour {
    [Header("Duration of the countdown in seconds")]
    [SerializeField] private float _duration;

    public float GetDuration { get { return _duration; } private set { } }

    [SerializeField] private bool _running;

    [SerializeField] private UnityEvent _onTimerEnd;
    public void StartTimer(float duration = 0) {
        if (duration != 0) {
            _duration = duration;
        }
        _running = true;
    }

    // Update is called once per frame
    void Update() {
        if (!_running) {
            return;
        }
        _duration -= Time.deltaTime;
        if (_duration <= 0) {
            _running = false;
            _onTimerEnd?.Invoke();
        }
    }

    public void StopTimer() {
        _running = false;
    }
}
