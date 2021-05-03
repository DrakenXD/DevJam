using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmountEnemyLive : MonoBehaviour
{
    public int amount; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] amountenemies = GameObject.FindGameObjectsWithTag("Enemy");
       
        foreach (GameObject enemy in amountenemies)
        {
        
            if (enemy.gameObject.GetComponent<EnemyController>().IsDead())
            {
                amount--;
            }
            amount = amountenemies.Length;
        }
       
    }
}
