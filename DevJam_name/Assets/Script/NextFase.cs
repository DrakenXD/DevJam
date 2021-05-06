using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextFase : MonoBehaviour
{
    public string scene;
    public float time;
    private float T;


    private void Start()
    {
        T = time;
       
    }

    private void Update()
    {
        NextScene();
    }

    public void NextScene()
    {
        if (GameController.finish && ElevatorController.playerInElevator)
        {
            if (T <= 0)
            {
                NameScene(scene);
            }
            else T -= Time.deltaTime;
        }
    }


    public void NameScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
