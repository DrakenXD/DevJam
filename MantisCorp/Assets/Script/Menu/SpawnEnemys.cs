using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[System.Serializable]
public class TypeEnemys
{
    public string NameEnemy;
    public GameObject prefabEnemy;
    [Range(0, 1)] public float ChMax;
    [Range(0, 1)] public float ChMin;
}

public class SpawnEnemys : MonoBehaviour
{
    [Header("          Components NextWave")]
    public static bool NexTwave;
    public float TimeNextWave;
    public float T_N_W;

    [Header("          Components NextSpawn")]
    public TypeEnemys[] enemys;
    public Transform[] enemySpawnpoint;
    public int AmountSpawn;
    public int amountS;
    public float NextSpawn;
    private float N_S;

    [Header("          NumberFloor")]
    [SerializeField] TextMeshProUGUI TxtAmountFloor;
    [SerializeField] private int AmountFloor;
    private void Start()
    {

        //ativar depois
        AmountFloor = PlayerPrefs.GetInt("AmountFloor");

        AmountFloor++;

        //AmountFloor = 0;

        TxtAmountFloor.SetText(""+AmountFloor);

        PlayerPrefs.SetInt("AmountFloor", AmountFloor);



        //ativar depois
        AmountSpawn = PlayerPrefs.GetInt("AmountSpawn");

        AmountSpawn += 5;

        //AmountSpawn =0;

        PlayerPrefs.SetInt("AmountSpawn", AmountSpawn);

 
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (T_N_W <= 0)
        {         
            if (amountS < AmountSpawn )
            {
                if (N_S <= 0)
                {
                    int indexSpawn = Random.Range(0, enemySpawnpoint.Length);

                    for (int i = 0; i < enemys.Length; i++)
                    {
                        if (Random.value < enemys[i].ChMax && Random.value > enemys[i].ChMin)
                        {
                            Instantiate(enemys[i].prefabEnemy, enemySpawnpoint[indexSpawn].position, Quaternion.identity);
                    
                        }
                    }

                    N_S = NextSpawn;

                    amountS++;
                }
                else
                {
                    N_S -= Time.deltaTime;
                }
            }

            if (amountS == AmountSpawn)
            {
                NexTwave = false;
                T_N_W = TimeNextWave;
                amountS = 0;
            }
         
        }
        else
        {
           if(NexTwave) T_N_W -= Time.deltaTime;
        }
        */

        if (amountS < AmountSpawn)
        {
            if (N_S <= 0)
            {
                int indexSpawn = Random.Range(0, enemySpawnpoint.Length);

                for (int i = 0; i < enemys.Length; i++)
                {
                    if (Random.value < enemys[i].ChMax && Random.value > enemys[i].ChMin)
                    {
                        Instantiate(enemys[i].prefabEnemy, enemySpawnpoint[indexSpawn].position, Quaternion.identity);

                    }
                }

                N_S = NextSpawn;

                amountS++;
            }
            else
            {
                N_S -= Time.deltaTime;
            }
        }



    }



    public void Testscene()
    {
        SceneManager.LoadScene("Menu");
    }
}
