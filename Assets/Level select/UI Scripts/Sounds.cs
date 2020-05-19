using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sounds
{
    public string name;
    public string audioType;
    public AudioClip clip;

    public bool loop;

    [HideInInspector] public AudioSource audioSource;
   
}