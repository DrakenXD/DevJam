using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TypeEnemys
{
    public string NameEnemy;
    public GameObject prefabEnemy;
    [Range(0,1)] public float chanceToSpawnMax;
    [Range(0, 1)] public float chanceToSpawnMin;
}

public class SpawnEnemys : MonoBehaviour
{
    public static bool NexTwave;
    public float TimeNextWave;
    public float T_N_W;

    public TypeEnemys[] enemys;
    public Transform[] enemySpawnpoint;
    public int AmountSpawn;
    public int amount;
    public float NextSpawn;
    private float N_S;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (T_N_W <= 0)
        {
           

            if (amount < AmountSpawn )
            {
                if (N_S <= 0)
                {
                    int indexSpawn = Random.Range(0, enemySpawnpoint.Length);

                    for (int i = 0; i < enemys.Length; i++)
                    {
                        if (Random.value < enemys[i].chanceToSpawnMax && Random.value > enemys[i].chanceToSpawnMin)
                        {
                            Instantiate(enemys[i].prefabEnemy, enemySpawnpoint[indexSpawn].position, Quaternion.identity);
                            Debug.Log(enemys[i].NameEnemy + " Spawn");
                        }
                    }

                    N_S = NextSpawn;

                    amount++;
                }
                else
                {
                    N_S -= Time.deltaTime;
                }

                
            }

            if (amount == AmountSpawn)
            {
                NexTwave = false;
                T_N_W = TimeNextWave;
                amount = 0;
            }

        }
        else
        {
           if(NexTwave) T_N_W -= Time.deltaTime;

        }
    }
}
