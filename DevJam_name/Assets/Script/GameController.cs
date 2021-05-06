using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Fase")]
    public static bool finish;
    public GameObject arrow;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        finish = false;

    }

    // Update is called once per frame
    void Update()
    {
        FinishFase();
    }

    public void FinishFase()
    {
        if (finish)
        {
            arrow.SetActive(true);
            anim.Play("ArrowFinish");
            
        }
        else
        {
            anim.Play("Elevator Up");
        }
       
    }
}
