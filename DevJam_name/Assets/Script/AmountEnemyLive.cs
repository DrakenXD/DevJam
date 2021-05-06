using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmountEnemyLive : MonoBehaviour
{
    public TextMeshProUGUI amounttxt;
    public int amount;
    public GameObject[] enemies;

    private void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        amount = enemies.Length;
    }

    // Update is called once per frame
    void Update()
    {
       

        if (enemies.Length>0)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

          
            amounttxt.SetText("" + enemies.Length);
        }
        else
        {
            GameController.finish = true;
        }

       
    }
}
