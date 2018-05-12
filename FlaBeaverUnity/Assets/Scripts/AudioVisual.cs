using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisual : MonoBehaviour {

    private const int SAMPLE_SIZE = 1024;

    public float rmsValue;
    public float dbValue;

    public GameObject visualObject;
    public GameObject squareboi;

    public float maxVisualScale = 25.0f;
    public float visualModifier = 120.0f;
    public float smoothSpeed = 10.0f;
    public float keepPercentage = 0.5f;

    public AudioSource source;
    private float[] samples;
    private float[] spectrum;
    private float sampleRate;

    private Transform[] visualList;
    private float[] visualScale;
    public int amountOfVisual = 70;

	// Use this for initialization
	void Start () {
        samples = new float[SAMPLE_SIZE];
        spectrum = new float[SAMPLE_SIZE];
        sampleRate = AudioSettings.outputSampleRate;

        SpawnLine();
	}

    void SpawnLine() {
        visualScale = new float[amountOfVisual];
        visualList = new Transform[amountOfVisual];

        for (int i = 0; i < amountOfVisual; i++)
        {
            GameObject go = Instantiate(squareboi, transform) as GameObject;
            go.transform.parent = visualObject.transform;
            visualList[i] = go.transform;
            visualList[i].position = new Vector3(0.75f, 0f, 0f) * i;
        }

        visualObject.transform.position = new Vector3(-15f,-5f,0f);
    }

	// Update is called once per frame
	void Update () {
        AnalyzeSound();
        UpdateVisual();
	}

    void UpdateVisual() {
        int visualIndex = 0;
        int spectrumIndex = 0;
        int averageSize = (int)((SAMPLE_SIZE * keepPercentage) / amountOfVisual);

        while (visualIndex < amountOfVisual)
        {
            int j = 0;
            float sum = 0;
            while (j < averageSize)
            {
                sum += spectrum[spectrumIndex];
                spectrumIndex++;
                j++;
            }

            float scaleY = sum / averageSize * visualModifier;
            visualScale[visualIndex] -= Time.deltaTime * smoothSpeed;
            if (visualScale[visualIndex] < scaleY)
            {
                visualScale[visualIndex] = scaleY;
            }

            if (visualScale[visualIndex] > maxVisualScale)
            {
                visualScale[visualIndex] = maxVisualScale;
            }

            visualList[visualIndex].localScale = new Vector3(0.75f,0.75f,0.75f) + Vector3.up * visualScale[visualIndex];
            visualIndex++;
        }
    }

    void AnalyzeSound() {
        source.GetOutputData(samples, 0);

        //Get RMS
        int i = 0;
        float sum = 0;
        for (; i < SAMPLE_SIZE; i++)
        {
            sum = samples[i] * samples[i];
        }
        rmsValue = Mathf.Sqrt(sum / SAMPLE_SIZE);

        //Get DB value
        dbValue = 20 * Mathf.Log10(rmsValue / 0.1f);

        //Get SoundSpectrum
        source.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);


    }
}
