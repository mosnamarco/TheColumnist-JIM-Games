using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] List<AudioClip> sfxLibrary, musicLibrary;
    [SerializeField] List<AudioSource> audioSoruces;

    private void Awake() {
        instance = this;    
    }

    public void KeyHit() {
        audioSoruces[0].PlayOneShot(sfxLibrary[0]);
    }

}
