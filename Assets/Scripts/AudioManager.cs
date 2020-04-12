using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    [Range(.1f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;

    public bool isLooping;
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] sounds;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.isLooping;
        }
    }

    private void Start()
    {
        StartMusic();
        PlaySound("Launching");
    }

    public void StartMusic()
    {
        PlaySound("Music");
    }

    public void PlaySound(string soundname)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundname);
        s.source.Play();

        if (s.source == null)
        {
            Debug.Log(soundname);
        }
    }

    public void StopSound(string soundname)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundname);
        s.source.Stop();
    }

    public void PauseSound(string soundname)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundname);
        s.source.Pause();
    }

    public void UnpauseSound(string soundname)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundname);
        s.source.Pause();
    }

    public void StopMusic()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "startMusic");
        s.source.Stop();
        Sound sm = Array.Find(sounds, sound => sound.name == "loopMusic");
        sm.source.Stop();
    }

    public bool IsPlaying(string soundname)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundname);
        return s.source.isPlaying;
    }
}