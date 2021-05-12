using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int numberofPlayers;
    public GameObject prefabPlayer;

    public List<PlayerController> activeplayerControllers;
    // Update is called once per frame
    void Update()
    {
        activeplayerControllers = new List<PlayerController>();

        for (int i = 0; i < numberofPlayers; i++) 
        {

        }
    }
}
