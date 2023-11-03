using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager _instance;
    public static AudioManager Instance => _instance;
    [SerializeField] public AudioSource[] AudioSources;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    public void AudioEnable(AudioSource audio)
    {
        if (!audio.isActiveAndEnabled)
        {
            audio.enabled = true;
            audio.Play();
        }
    }
    public void AudioDisable(AudioSource audio)
    {
        if (audio.isActiveAndEnabled)
        {
            audio.enabled = false;
            audio.Stop();
        }
    }
}
