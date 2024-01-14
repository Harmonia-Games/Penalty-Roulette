using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundForButtons : MonoBehaviour
{
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }

}
