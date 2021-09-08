using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualizer : MonoBehaviour
{
    public AudioSource audioSourceBass;
    public AudioSource audioSourceMids;
    public AudioSource audioSourceCorus;


    public float updateStep = 0.01f;
    public int sampleDataLenght = 1024;
    private float currentUpdateTime = 0f;
    private float clipLoudnessBass;
    private float clipLoudnessMids;
    private float clipLoudnessCorus;

    private float[] clipSampleData;
    public GameObject filter;
    public float sizeFactor = 1;
    public float minSize = 0;
    public float maxSize = 10;

    public Renderer meshRenderer;
    public Material filterMaterial;

    private void Awake()
    {
        clipSampleData = new float[sampleDataLenght];

    }
    void Start()
    {
        meshRenderer = gameObject.GetComponent<Renderer>();
        filterMaterial = meshRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        currentUpdateTime += Time.deltaTime;
        if (currentUpdateTime >= updateStep)
        {
            currentUpdateTime = 0f;
            audioSourceBass.clip.GetData(clipSampleData, audioSourceBass.timeSamples);
            audioSourceCorus.clip.GetData(clipSampleData, audioSourceCorus.timeSamples);
            audioSourceMids.clip.GetData(clipSampleData, audioSourceMids.timeSamples);

            clipLoudnessBass = 0f;
            clipLoudnessCorus = 0f;
            clipLoudnessMids = 0f;


            foreach (var sample in clipSampleData)
            {
                clipLoudnessBass += Mathf.Abs(sample);
                clipLoudnessMids += Mathf.Abs(sample);
                clipLoudnessCorus += Mathf.Abs(sample);
            }

            clipLoudness(clipLoudnessBass);
            clipLoudness(clipLoudnessCorus);
            clipLoudness(clipLoudnessMids);

            filterMaterial.SetFloat("RefractionPower", clipLoudnessBass / 300);          // bass     //Noise
            // filterMaterial.SetFloat("RefractionPower", clipLoudnessMids / 50);      // mids     //Refraction
            /// filterMaterial.SetFloat("TwirlStranght", clipLoudnessCorus / 30);      // corus    //Twirl

        }

    }
    private void clipLoudness(float clipLoudness)
    {
        clipLoudness /= sampleDataLenght;
        clipLoudness *= sizeFactor;
        clipLoudness = Mathf.Clamp(clipLoudness, minSize, maxSize);
    }
}
