using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public FadeController fade;
    public NextFase fase;
    public static bool playerInElevator;
    private void Start()
    {
        playerInElevator = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && GameController.finish)
        {
            playerInElevator = true;
            fade.AnimTelaPreta();
        }
    }
}
