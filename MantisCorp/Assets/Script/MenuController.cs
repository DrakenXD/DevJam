using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Animator anim;
    new public string name;
    [SerializeField] private GameObject setWindowleft;
    [SerializeField] private Animator animFade;
    [SerializeField] private Animator animCenario;

    public void ActivateDown()
    {
        anim.SetTrigger("DownActivate");
    }

    public void ActivateControle(bool _activate)
    {
        anim.SetBool("Controles",_activate);
    }

    public void ActivateCreditos(bool _activate)
    {
        anim.SetBool("Creditos", _activate);
    }

    public void NewScene()
    {
       

        if(GameController.AddPlayers > 1)
        {
            GameController.IsMultiPlayer = true;
        }
        else
        {
            GameController.IsMultiPlayer = false;
        }

        SceneManager.LoadScene(name);

        
    }
    public void StartGame()
    {
        anim.Play("StartGame");
        animCenario.Play("ElevatorStartGame");
    }
    public void StartFade()
    {
        animFade.Play("IniciandoFade");
    }
    public void SetWindow()
    {
        setWindowleft.SetActive(true);
    }
}
