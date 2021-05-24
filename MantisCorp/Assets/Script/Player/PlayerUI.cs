using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public int IDPlayer;

    [Header("UI")]
    public GameObject UICanvas;
    public Image Imagelife;
    public TextMeshProUGUI AmountBullet;
    public GameObject UIRevive;
    public TextMeshProUGUI timerevive;

    public PlayerInput inputplayer;

    



    private void Start()
    {
        IDPlayer = inputplayer.user.index;

        if (IDPlayer == 1) UICanvas.transform.position = new Vector2(UICanvas.transform.position.x - 475, UICanvas.transform.position.y);
    }

    public void BarLife(float min, float max)
    {
        
        Imagelife.fillAmount = min / max;
    }

    public void TextBullet(float min, float max)
    {
      
        AmountBullet.SetText(min + " /" + max);
    }
    public void TextTimeRevive(float time, bool isActive)
    {
        UIRevive.SetActive(isActive);
        timerevive.SetText(time.ToString("0"));
    }
}
