using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class MenuController : MonoBehaviour
{
    public  float volume;
    public AudioMixer audio;

    private void Start()
    {
        audio.GetFloat("Geral",out volume);
    }
    public void SetVolume(float vol)
    {
        volume = vol;
        audio.SetFloat("Geral",Mathf.Log10(vol)*20);
        
    }
}
