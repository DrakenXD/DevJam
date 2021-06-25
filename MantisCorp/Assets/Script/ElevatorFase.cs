using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorFase : MonoBehaviour
{
    [SerializeField] private Animator animFade;
    
    [SerializeField] private new string nameShop;

    [SerializeField] private float TimeNextScene;

    [SerializeField] GameObject Arrow;

    public bool GoNextFase;

    private void LateUpdate()
    {
        if (GoNextFase)
        {
            Arrow.SetActive(true);
        }
    }

    private void SceneShop()
    {
        SceneManager.LoadScene(nameShop);
    }
    public void StartFade()
    {
        animFade.Play("IniciandoFade");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && GoNextFase)
        {
            Invoke("SceneShop", TimeNextScene);
            PlayerController.canmove = false;
            StartFade();
        }
    }
}
