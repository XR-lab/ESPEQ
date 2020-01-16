using System.Collections; 
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    /// <summary>
    /// Fades the alpha of a UI image component
    /// </summary>
    [SerializeField]
    private UnityEvent _onFadeIn; // When faded in
    public UnityEvent OnFadeIn
    {
        get { return _onFadeIn; }
        private set {}
    }

    [SerializeField]
    private UnityEvent _onFadeOut; // When faded out
    public UnityEvent OnFadeOut
    {
        get { return _onFadeOut; }
        private set { }
    }

    [SerializeField]
    private double _fadeSpeedRate; // The speed it fades

    [SerializeField]
    private bool _fadeOnStart = false; // Fades on start

    [SerializeField]
    private float _delayIn; // delay time before fading in

    [SerializeField]
    private float _delayOut; // delay time before fading out

    private bool _faded; // When its faded in
    private Image _image; // The UI Image 

    void Awake()
    {
        _image = GetComponent<Image>();
        if (_image.color.a == 0)
        {
            _faded = false;
        }
        else
        {
            _faded = true;
        }
    }

    void Start()
    {
        if (_fadeOnStart)
        {
            ToggleFade();
        }
    }

    // Fades the alpha to 1 so the color is visible with aditional callback
    private IEnumerator FadeIn()
    {
        float r = _image.color.r;
        float g = _image.color.g;
        float b = _image.color.b;

        yield return new WaitForSeconds(_delayIn);

        for (float i = 0; i < 1; i += (float)_fadeSpeedRate)
        {
            _image.color = new Color(r, g, b, i);
            yield return new WaitForEndOfFrame();
        }
        _onFadeIn?.Invoke();
    }

    // Fades the color with aditional callback
    private IEnumerator FadeOut()
    {
        float r = _image.color.r;
        float g = _image.color.g;
        float b = _image.color.b;
        float a = _image.color.a;

        yield return new WaitForSeconds(_delayOut);

        for (double i = a; i > 0 - _fadeSpeedRate; i -= _fadeSpeedRate)
        {
            _image.color = new Color(r, g, b, (float)i);
            yield return new WaitForEndOfFrame();
        }
        _onFadeOut?.Invoke();
    }

    // Toggles the fade
    public void ToggleFade()
    {
        if (_faded)
        {
            StartCoroutine(FadeOut());
        }
        else
        {
            StartCoroutine(FadeIn());
        }
        _faded = !_faded;
    }
}
