using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Cinemachine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public static bool IsMultiPlayer;

    [Header("          Type Camera")]
    public GameObject Solo;
    public GameObject Multiplayer;

    [Header("          Cinemachine")]
    public CinemachineVirtualCamera _camfollow;
    public CinemachineTargetGroup _cinemachine;

    [Header("          Players")]
    public GameObject player;
    public GameObject[] players;

    [Header("          AmountPlayer")]
    public PlayerInputManager input;
    public static int AddPlayers;
    public int amountplayers;

    [Header("          UI")]
    public TextMeshProUGUI amountEnemys;
    public GameObject[] enemys;

    [Header("          Elevator")]
    public ElevatorFase elevator;
    private void Start()
    {

        instance = this;

        if (IsMultiPlayer)
        {
            Solo.SetActive(false);
            Multiplayer.SetActive(true);
        }
        else
        {
            Solo.SetActive(true);
            Multiplayer.SetActive(false);
        }

        

    }

    private void LateUpdate()
    {
        if (IsMultiPlayer)
        {
          
           
            if (amountplayers < AddPlayers)
            {
                players = GameObject.FindGameObjectsWithTag("Player");

                input.JoinPlayer();

                _cinemachine.AddMember(players[amountplayers].transform, 1, 0);

                amountplayers++;

            }

           

        }
        else
        {
            if (amountplayers < 1)
            {
              
                input.JoinPlayer();

                player = GameObject.FindGameObjectWithTag("Player");

                _camfollow.m_Follow = player.transform;

                amountplayers++;
            }

         
        }
        
        enemys = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemys.Length == 0)
        {
            elevator.GoNextFase = true;
            //SpawnEnemys.NexTwave = true;
        }
            

        amountEnemys.SetText("" + enemys.Length);
    }
}
