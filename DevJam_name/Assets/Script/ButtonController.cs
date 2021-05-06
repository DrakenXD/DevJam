using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChooseAudio
{
    public AudioSource song;
 
}
public class ButtonController : MonoBehaviour
{
    public ChooseAudio[] audio;
    public int EscolherBotao;
    public int ApertarBotao;
    public void SetAudio(int i)
    {
        audio[i].song.Play();
    }


    private void OnMouseEnter()
    {
        SetAudio(EscolherBotao);
    }
    private void OnMouseDrag()
    {
        SetAudio(ApertarBotao);
    }
}
