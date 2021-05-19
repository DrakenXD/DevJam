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
    

    public PlayerInput inputplayer;

    



    private void Start()
    {
        IDPlayer = inputplayer.user.index;

        if (IDPlayer == 1) UICanvas.transform.position = new Vector2(300, 140);
    }

    public void BarLife(float min, float max)
    {
        
        Imagelife.fillAmount = min / max;
    }

    public void TextBullet(float min, float max)
    {
      
        AmountBullet.SetText(min + " /" + max);
    }
}
