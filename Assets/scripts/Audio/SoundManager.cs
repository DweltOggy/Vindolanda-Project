using UnityEngine.Audio;
using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public Sound[] sounds;

    public static SoundManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
    }

    private void Start()
    {
        Play("BackGround1");
    }

    public void Play(string Name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == Name);
        if (s == null)
        {
            return;
        }
        s.source.Play();
    }

    public void Stop(string Name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == Name);
        if (s == null)
            return;
        s.source.Stop();
    }

    public bool alreadyPlaying(string Name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == Name);

        if (s.source.isPlaying)
            return true;

        return false;
    }

    public void stopLoops()
    {
        foreach(Sound s in sounds)
        {
            if(s.loop)
                Stop(s.name);
        }
    }

}
