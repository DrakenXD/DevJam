using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Cinemachine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [Header("          Cinemachine")]
    public CinemachineTargetGroup _cinemachine;
    public GameObject[] players;

    public PlayerInputManager input;
    public static int AddPlayers;
    public int amountplayers;

    [Header("          UI")]
    public TextMeshProUGUI amountEnemys;
    public GameObject[] enemys;

    private void Start()
    {
        

        instance = this;

    }

    private void LateUpdate()
    {
        players = GameObject.FindGameObjectsWithTag("Player");



        if (amountplayers < AddPlayers)
        {
            input.JoinPlayer();

            _cinemachine.AddMember(players[amountplayers].transform, 1, 0);

            amountplayers++;
        }
        else Debug.Log("Sem Jogador");
        
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        amountEnemys.SetText("" + enemys.Length);
    }

    public void SetPlayer(int _amount)
    {
        AddPlayers = _amount;
    }
}
