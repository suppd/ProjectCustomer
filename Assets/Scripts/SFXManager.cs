using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    AudioSource audioSource;

    public float volumeScale;

    public AudioClip carStart;
    public AudioClip carDriving;
    public CarTransition carScript;
    bool startSoundPlayed;
    AudioSettings audioSettings;
    float timer = 0f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        startSoundPlayed = false;
        volumeScale = 1f;
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
