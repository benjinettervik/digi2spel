using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [Header("Footsteps")]
    public AudioClip step1;
    public AudioClip step2;
    public AudioClip step3;

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
        int random = Random.Range(0, 1);
        switch (random)
        {
            case 0:
                audioSources[0].clip = step1;
                break;
            case 1:
                audioSources[0].clip = step2;
                break;
            case 2:
                audioSources[0].clip = step3;
                break;
        }

        audioSources[0].Play();
    }
}
