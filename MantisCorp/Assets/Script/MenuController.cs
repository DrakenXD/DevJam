using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Animator anim;
    new public string name;

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

    public void NewScene(int amountplayers)
    {
        GameController.AddPlayers = amountplayers;

        if(amountplayers > 1)
        {
            GameController.IsMultiPlayer = true;
        }
        else
        {
            GameController.IsMultiPlayer = false;
        }

        SceneManager.LoadScene(name);

        
    }
}
