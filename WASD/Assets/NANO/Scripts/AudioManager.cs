using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource MusicSource;
    [SerializeField]
    private AudioSource SFXSource;

    public AudioClip Music;
    public AudioClip Grass;
    private void Start()
    {
        PlayMusic();
    }

    private void PlayMusic()
    {
        MusicSource.clip = Music;
        MusicSource.Play();
    }

    public void PlaySFX(AudioClip audioClip)
    {
        SFXSource.PlayOneShot(audioClip);
    }
}
