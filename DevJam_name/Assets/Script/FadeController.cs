using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{

    public bool TelaPreta;
    public bool TelaNormal;

    public Animator anim;
    public GameObject tela;
    // Update is called once per frame
    private void Start()
    {
        if (TelaPreta)
        {

            anim.Play("TelaPreta");
        }
        else if (TelaNormal)
        {

            anim.Play("TelaNormal");
        }
    }
    public void AnimTelaPreta()
    {
        anim.Play("TelaPreta");
    }
    public void AnimTelaNormal()
    {
        anim.Play("TelaNormal");
    }
    public void TelaAtivada()
    {
        tela.SetActive(true);
    }
    public void TelaDesativada()
    {
        tela.SetActive(false);
    }
}
