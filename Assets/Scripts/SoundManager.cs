using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
    //Med hj�lp av denna variablen vi kan g�ra att andra script kan ha tillg�ng till den. Men instance g�r att de kommer sparas som enda kopia Martin
{ 
    public static SoundManager instance { get; private set; }
    private AudioSource source;
   
    //Tar up Audio soure component Martin
    private void Awake()
    {
        instance = this;
        source= GetComponent<AudioSource>();
    }

    // Audio Clippet kommer spellas up men hj�lp av PlayOneShot, den kommer bara spellas up en g�ng Martin
    public void PlaySound(AudioClip _sound)
    {
        source.PlayOneShot(_sound);
    }
}
