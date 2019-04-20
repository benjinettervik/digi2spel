using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [Header("Footsteps")]
    public AudioClip step1;

    // 0 = footsteps
    // 1 = swordstuff
    AudioSource[] audioSources;

    private void Start()
    {
        audioSources = GetComponents<AudioSource>();
        audioSources[0].clip = step1;
    }

    public void PlayStep()
    {
        audioSources[0].Play();
    }
}
