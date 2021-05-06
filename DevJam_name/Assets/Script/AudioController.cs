using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Audio
{
    public string name;
    public AudioSource audio;
    public bool Activate;
}
public class AudioController : MonoBehaviour
{
    public Audio[] song;

    public void SetAudio()
    {
        foreach (Audio audio in song)
        {
            if (audio.Activate)
            {
                audio.audio.Play();
            }
        }
    }


    
}
