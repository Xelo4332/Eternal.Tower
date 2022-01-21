using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
    //Med hjälp av denna variablen vi kan göra att andra script kan ha tillgång till den. Men instance gör att de kommer sparas som enda kopia Martin
{ 
    public static SoundManager instance { get; private set; }
    private AudioSource source;
   
    //Tar up Audio soure component Martin
    private void Awake()
    {
        instance = this;
        source= GetComponent<AudioSource>();
    }

    // Audio Clippet kommer spellas up men hjälp av PlayOneShot, den kommer bara spellas up en gång Martin
    public void PlaySound(AudioClip _sound)
    {
        source.PlayOneShot(_sound);
    }
}
