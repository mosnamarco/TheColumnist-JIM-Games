using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongPlayer : MonoBehaviour
{
    private GameObject parentObject;
    private AudioSource mainAudioSource;
    private AudioSource currentAudioSource;
    private void Start()
    {
        mainAudioSource = GameObject.Find("Audio Source - Record Player").GetComponent<AudioSource>();
        currentAudioSource = GetComponent<AudioSource>();
    }

    public void playSong()
    {
        mainAudioSource.clip = currentAudioSource.clip;
        mainAudioSource.Play();
    }

    //private void Start()
    //{
    //    mainAudioSource = GetComponent<AudioSource>();
    //    parentObject = GameObject.Find("Content");
    //}
    //public void playSong()
    //{
    //    bool audioPlaying = false;

    //    // Get all the audio sources in the scene
    //    AudioSource[] audioSources = parentObject.GetComponentsInChildren<AudioSource>();

    //    // Loop through each audio source and check if it's playing
    //    foreach (AudioSource audioSource in audioSources)
    //    {
    //        if (audioSource.isPlaying)
    //        {
    //            audioPlaying = true;
    //            break;
    //        }
    //    }

    //    if (!audioPlaying)
    //    {
    //        mainAudioSource.Play();
    //    } else
    //    {
    //        foreach (AudioSource audioSource in audioSources)
    //        {
    //            if (audioSource.isPlaying)
    //            {
    //                audioSource.Stop();
    //                mainAudioSource.Play();
    //                break;
    //            }
    //        }
    //    }
    //}
}
