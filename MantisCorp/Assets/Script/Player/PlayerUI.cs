using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public int IDPlayer;

    public GameObject UIAmountBullet;

    public PlayerInput inputplayer;

    public TextMeshProUGUI AmountBullet;

    private void Start()
    {
        IDPlayer = inputplayer.user.index;

        if (IDPlayer == 1) UIAmountBullet.transform.position = new Vector2(300, 140);
    }

    public void TextBullet(float min, float max)
    {
        AmountBullet.SetText(min + " /" + max);
    }
}
