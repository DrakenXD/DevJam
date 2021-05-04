﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldController : MonoBehaviour
{
    [Header("Stats")]

    public float life;
    public bool isbroken;

    private void Start()
    {
     
    }

    public void TakeDamage(float dmg)
    {
        life -= 1;



        if (BrokenShield()) {
            gameObject.SetActive(false);
            isbroken = true; ;
        }
    }

    public bool BrokenShield()
    {
        if (life <= 0) 
        {
            return true;
            
        }
        else
        {
            return false;
        }
    }
}
