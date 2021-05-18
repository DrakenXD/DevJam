using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameController : MonoBehaviour
{
    public CinemachineTargetGroup _cinemachine;

    public GameObject[] players;

    public int amountplayers;

   
    private void LateUpdate()
    {
        players = GameObject.FindGameObjectsWithTag("Player");

        if (amountplayers < players.Length)
        {
            _cinemachine.AddMember(players[amountplayers].transform, 1, 0);

            amountplayers++;
        }

       
    }
}
