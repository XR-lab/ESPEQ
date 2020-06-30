    using System.Collections.Generic;
using UnityEngine;

public class SetAudio : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _clips;
    private AudioSource _source;
    [SerializeField]private List<bool> _played;
    
    private void Start()
    {
        _source = gameObject.GetComponent<AudioSource>();
    }

    public void AudioSetter(int i)
    {
        if (_played[i])
            return;
        
        _source.Stop();
        _source.clip = _clips[i];
        _source.Play();
        _played[i] = true;
    }
}
