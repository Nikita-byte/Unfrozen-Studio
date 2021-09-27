﻿using System.Collections.Generic;
using UnityEngine;


public class SoundManager
{
    public static SoundManager Instance = new SoundManager();

    private Dictionary<string, GameObject> _sounds;
    private List<AudioSource> _sources;
    private AudioListener _audioListener;
    GameObject sound = new GameObject("Sound");

    public Dictionary<string, GameObject> Sounds
    {
        get 
        {
            return _sounds;
        }
    }

    public SoundManager()
    {
        _sounds = new Dictionary<string, GameObject>();
        _sources = new List<AudioSource>();

        _sounds = ObjectPool.Instance.GetSounds();
    }

    public void PlaySound(SoundType soundType)
    {
        switch (soundType)
        {
            case SoundType.Music:
                Sounds["Music"].GetComponent<AudioSource>().Play();
                break;
        }

    }

    public void StopSound(SoundType soundType)
    {
        switch (soundType)
        {
            case SoundType.Music:
                Sounds["Music"].GetComponent<AudioSource>().Stop();
                break;
        }

    }

    public void SetVolume(float volume)
    {
        foreach (AudioSource source in _sources)
        {
            source.volume = volume;
        }
    }
}
