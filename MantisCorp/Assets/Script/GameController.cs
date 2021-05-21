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
    public GameObject prefabPlayer;
    public Transform spawnpoint;
    public GameObject player;
    public GameObject[] players;

    [Header("          AmountPlayer")]
    public PlayerInputManager input;
    public static int AddPlayers;
    public int amountplayers;

    [Header("          UI")]
    public TextMeshProUGUI amountEnemys;
    public GameObject[] enemys;

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
            players = GameObject.FindGameObjectsWithTag("Player");
            if (amountplayers < AddPlayers)
            {
                input.JoinPlayer();

                _cinemachine.AddMember(players[amountplayers].transform, 1, 0);

                amountplayers++;
            }
            else Debug.Log("Sem Jogador");
        }else
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
        amountEnemys.SetText("" + enemys.Length);
    }
}
