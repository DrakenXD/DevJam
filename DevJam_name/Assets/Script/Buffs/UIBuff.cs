using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIBuff : MonoBehaviour
{
    public Buff buff;
    public Image icon;
    public TextMeshProUGUI time;

    private void Update()
    {
        if (buff != null)
        {
            time.SetText(""+buff.usage_time.ToString("0.00"));
        }
    }

    public void AddImage(Buff _buff)
    {
        buff = _buff;

        icon.enabled = true;
        icon.sprite = buff.icon;

        time.enabled = true;


    }

    public void RemoveImage()
    {
        buff = null;

        icon.enabled = false;
        icon.sprite = null;

        time.enabled = false;
    }
}
