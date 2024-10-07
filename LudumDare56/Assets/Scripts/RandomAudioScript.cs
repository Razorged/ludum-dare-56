using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudioScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] sounds;

    private void PlaySound()
    {
        System.Random r = new System.Random();
        int rInt = r.Next(sounds.Length);
        audioSource.clip = sounds[rInt];
        audioSource.Play();
    }

    private void Start()
    {
        PlaySound();
    }

}
