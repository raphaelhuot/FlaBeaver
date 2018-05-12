using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneScript : MonoBehaviour {
    public float sensitivity = 100;
    public float loudness = 0;
    AudioSource myAudio;
	// Use this for initialization
	void Start () {
        myAudio = GetComponent<AudioSource>();
        myAudio.clip = Microphone.Start(null, true, 10, 44100);
        myAudio.loop = true;
        myAudio.mute = true;
        while (!(Microphone.GetPosition(null) > 0)) { }
        myAudio.Play();
	}
	
	// Update is called once per frame
	void Update () {
        loudness = GetAverageVolume() * sensitivity;
        Debug.Log(loudness);
	}

    float GetAverageVolume()
    {
        float[] data = new float[256];
        float a = 0;
        myAudio.GetOutputData(data, 0);
        foreach(float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 256;
    }
}
