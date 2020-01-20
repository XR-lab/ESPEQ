using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplayer : MonoBehaviour {

    [SerializeField] private Timer _timer;

    [SerializeField] private Text _text;

    private string _convertedText = "00:00";

    void Update() {
        _text.text = ConvertTime(_timer.GetDuration);
    }

    string ConvertTime(float rawTime) {
        string str = "";
        string leftSide = "";
        string rightSide = "";
        if (rawTime <= 0) {
            str = "00:00";
        }
        int secs = (int)rawTime;
        int mins = secs / 60;
        leftSide = mins.ToString();
        while (leftSide.Length < 2) {
            leftSide = "0" + leftSide;
        }
        rightSide = (secs - (mins * 60)).ToString();
        while (rightSide.Length < 2) {
            rightSide = "0" + rightSide;
        }
        str = leftSide + ":" + rightSide;
        return str;
    }
}
