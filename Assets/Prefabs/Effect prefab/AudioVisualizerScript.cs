using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class AudioVisualizerScript : MonoBehaviour
{
    public AudioSource audioSourceBass;
    public AudioSource audioSourceMids;
    public AudioSource audioSourceCorus;


    public float updateStep = 0.01f;
    public int sampleDataLenght = 1024;
    private float currentUpdateTime = 0f;
    public float clipLoudnessBass;
    public float clipLoudnessMids;
    public float clipLoudnessCorus;

    private float[] clipSampleData;
    public GameObject PostProcessing;
    public float sizeFactor = 1;
    public float minSize = -0.2f;
    public float maxSize = 0.2f;


    private void Awake()
    {
        clipSampleData = new float[sampleDataLenght];

    }
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        currentUpdateTime += Time.deltaTime;
        if (currentUpdateTime >= updateStep)
        {
            currentUpdateTime = 0f;

            UnityEngine.Rendering.VolumeProfile volumeProfile = GetComponent<UnityEngine.Rendering.Volume>()?.profile;
            if (!volumeProfile) throw new System.NullReferenceException(nameof(UnityEngine.Rendering.VolumeProfile));
            //============================= Bass    =======================================//
            audioSourceBass.clip.GetData(clipSampleData, audioSourceBass.timeSamples);
            clipLoudnessBass = 0f;
            foreach (var sample in clipSampleData)
            {
                clipLoudnessBass += Mathf.Abs(sample);
            }
            clipLoudnessBass *= sizeFactor;


            UnityEngine.Rendering.Universal.LensDistortion lensDistortion;
            if (!volumeProfile.TryGet(out lensDistortion)) throw new System.NullReferenceException(nameof(lensDistortion));

            lensDistortion.intensity.Override((clipLoudnessBass * 0.2f) - 0.1f);




            //============================= Corus    =======================================//
            audioSourceCorus.clip.GetData(clipSampleData, audioSourceCorus.timeSamples);
            clipLoudnessCorus = 0f;
            foreach (var sample in clipSampleData)
            {
                clipLoudnessCorus += Mathf.Abs(sample);
            }
            clipLoudnessCorus *= sizeFactor;


            UnityEngine.Rendering.Universal.ChromaticAberration chromaticAberration;
            if (!volumeProfile.TryGet(out chromaticAberration)) throw new System.NullReferenceException(nameof(chromaticAberration));
            chromaticAberration.intensity.Override(clipLoudnessCorus);

            //============================= Mids     =======================================//
            audioSourceMids.clip.GetData(clipSampleData, audioSourceMids.timeSamples);
            clipLoudnessMids = 0f;
            foreach (var sample in clipSampleData)
            {
                clipLoudnessMids += Mathf.Abs(sample);
            }
            clipLoudnessMids *= sizeFactor;


            UnityEngine.Rendering.Universal.MotionBlur motionBlur;
            if (!volumeProfile.TryGet(out motionBlur)) throw new System.NullReferenceException(nameof(motionBlur));
            motionBlur.intensity.Override(clipLoudnessMids + 0.25f);
        }

    }
    private void clipLoudness(float clipLoudness, AudioSource audioSource)
    {
        audioSource.clip.GetData(clipSampleData, audioSourceBass.timeSamples);
        clipLoudness = 0f;
        foreach (var sample in clipSampleData)
        {
            clipLoudness += Mathf.Abs(sample);
        }

        //clipLoudness /= sampleDataLenght;
        clipLoudness *= sizeFactor;
        //clipLoudness = Mathf.Clamp(clipLoudness, minSize, maxSize);
        Debug.Log(clipLoudness);
    }
}
