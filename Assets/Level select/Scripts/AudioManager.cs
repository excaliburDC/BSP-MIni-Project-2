using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    public  AudioMixer Mixer;
    

    public void SetVolume(float Volume)
    {
        Mixer.SetFloat("MainVoume", Mathf.Log10(Volume)*20);
    }
    
    
}
