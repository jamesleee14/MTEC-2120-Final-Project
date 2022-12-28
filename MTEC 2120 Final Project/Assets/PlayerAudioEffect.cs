using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioEffect : MonoBehaviour
{
    public int SampleWindow = 64;
    private AudioClip microphoneClip;
    // Start is called before the first frame update
    void Start()
    {
        MicrophoneToAudioClip();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MicrophoneToAudioClip()
    {
        string microphoneName = Microphone.devices[0];
        microphoneClip = Microphone.Start(microphoneName, true, 20, AudioSettings.outputSampleRate);
    }

    public float GetLoudnessFromMicrophone()
    {
        return GetLoudnessFromAudioClip(Microphone.GetPosition(Microphone.devices[0]), microphoneClip);
    }
    public float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip)
    {
        int startPosition = clipPosition - SampleWindow;

        if (startPosition < 0)
            return 0;

        float[] waveData = new float[SampleWindow];
        clip.GetData(waveData, startPosition);

        float totalLoudness = 0;
        for (int i = 0; i < SampleWindow; i++)
        {
            totalLoudness += Mathf.Abs(waveData[i]);
        }
        return totalLoudness / SampleWindow;

    }
}
