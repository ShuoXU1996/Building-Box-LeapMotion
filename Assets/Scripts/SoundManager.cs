using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    private static SoundManager _instance;
    public static SoundManager Instance { get { return _instance; } }

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        _instance = this;
    }

    public bool IsAudioPlay()
    {
        return audioSource.isPlaying;

    }

    public void PlayAudio(AudioClip ac)
    {
        AudioSource.PlayClipAtPoint(ac, Camera.main.transform.position);
    }

    public void PlayAudioByName(string name)
    {
        
        audioSource.volume = 0.05f;
        AudioClip ac = Resources.Load<AudioClip>("Sound/" + name);
        PlayAudio(ac);
    }

    public void PlayMusic(AudioClip ac)
    {
      
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        this.audioSource.clip = ac;
        audioSource.Play();
    }

    public void PlayMusicByName(string name)
    {
        
        audioSource.volume = 0.1f;
        AudioClip ac = Resources.Load<AudioClip>("Sound/" + name);
        PlayMusic(ac);
       
    }

    public void StopMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

}
