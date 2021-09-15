using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    AudioSource audioSource;

    public float volumeScale;
    public AudioClip carStart;
    public AudioClip carDriving;
    public AudioClip carCrash1;
    public AudioClip carCrash2;
    public CarTransition carScript;
    public ConcentrationBar concentrationBar;


    bool crashSoundPlayed;
    bool startSoundPlayed;
    AudioSettings audioSettings;
    float timer = 0f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        startSoundPlayed = false;
        crashSoundPlayed = false;
        volumeScale = 0.2f;
    }

    void Update()
    {
        
        if (carScript.playerIn && startSoundPlayed == false)
        {
            PlayStartEngine();
            startSoundPlayed = true;
        }
        timer -= Time.deltaTime;
        if (startSoundPlayed == true && audioSource.isPlaying == false)
        {
          
            if (timer <= 0)
            {
                PlayCarDriving();
                timer = 5.90f;
            }
        }
        if (concentrationBar.healthAmount <= 1f && crashSoundPlayed == false)
        {
            PlayCrashSound();
            //audioSource.PlayOneShot(carCrash2, volumeScale);
            
        }
    }

    void PlayCrashSound()
    {
        audioSource.PlayOneShot(carCrash1, volumeScale);
        crashSoundPlayed = true;
    }
    void PlayStartEngine()
    {
        audioSource.PlayOneShot(carStart,volumeScale);
    }

    void PlayCarDriving()
    {
        audioSource.PlayOneShot(carDriving,volumeScale);
    }
}
