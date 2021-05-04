using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartFase : MonoBehaviour
{
    public string scene;
    public float time;
    private float T;
    private PlayerController player;


    private void Start()
    {
        T = time;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }


    // Update is called once per frame
    void Update()
    {
        if (player.IsDead())
        {
            if (T <= 0)
            {
                RestartScene(scene);
            }
            else T -= Time.deltaTime;
        }
    }



    public void RestartScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
