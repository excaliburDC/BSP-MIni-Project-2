﻿using UnityEngine;

public class AudioSetting : MonoBehaviour
{
   // private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private float backgroundFloat, soundeffectsFloat;
    //public AudioSource backgroundAudio;
    public AudioSource[] soundeffectsAudio;


    void Awake()
    {
        ContinueSetting();
    }
    private void ContinueSetting()
    {
        //if(backgroundAudio==null)
        //{
        //    Debug.Log("This Scene does not require a background music");
        //    return;
        //}
        //backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
        soundeffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);

       // backgroundAudio.volume = backgroundFloat;
        for (int i = 0; i < soundeffectsAudio.Length; i++)
        {
            soundeffectsAudio[i].volume = soundeffectsFloat;
        }
    }
}
