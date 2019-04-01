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
    }

    float timesincestep;
    private void Update()
    {

    }

    public void PlayStep()
    {
        audioSources[0].Play();
    }
}
