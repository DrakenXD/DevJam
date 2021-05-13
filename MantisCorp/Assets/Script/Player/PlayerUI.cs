using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{

    public TextMeshProUGUI AmountBullet;

    public void TextBullet(float min, float max)
    {
        AmountBullet.SetText(min + " /" + max);
    }
}
