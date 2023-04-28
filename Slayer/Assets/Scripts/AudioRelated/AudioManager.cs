using System;

using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
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

    public void PlayAudio(string soundName)
    {
        Sound soundToPlay = Array.Find(sounds, sound => sound.name == soundName);
        if (soundToPlay != null)
        {
            Debug.LogError("Sound: " + soundName + " not found!");
            return;
        }
        soundToPlay.source.Play();
    }
}
