using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    private AudioSource source;
   
    private void Awake()
    {
        instance = this;
        source= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlaySound(AudioClip _sound)
    {
        source.PlayOneShot(_sound);
    }
}
