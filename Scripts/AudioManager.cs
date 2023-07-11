using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class AudioManager : MonoBehaviour
{
    private AudioManager Audio;

    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip audio;

        [Range(0f, 1f)]
        public float volume;
        [Range(.1f, 3f)]
        public float pitch;

        [HideInInspector]
        public AudioSource source;
    }

    private Sound sound;
    public bool start;
    public Sound[] sounds;
    public Text captions2;

    private float time;
    private bool time2;

    public void Start()
    {
        sound = this.gameObject.GetComponent<Sound>();
        Audio = FindObjectOfType<AudioManager>();
    }

    void Awake()
    {
        if (start == true)
        {
            captions2.text = "Let the games commense!";
        }
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.audio;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Update()
    {
        if (start == true)
        {
            if (time2 == false)
            {
                time += Time.deltaTime;
            }
            if (time >= 3)
            {
                captions2.text = "";
                time2 = true;
                time = 0f;
            }
        }
    }


    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    public void Captions(string caption)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            captions2.text = caption;
        }
    }
}
