using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GranadeController : MonoBehaviour
{
    [Header("Granade")]
    public GameObject granade;
    public Transform pointShootGranade;

    [Header("Stats Granade")]
    public float G_damage;
    public float G_bulletvelocity;

    [Header("Timing")]
    public float nextTime;
    private float N_T;
    public bool Jogar;

    [Header("Ammunition Weapon")]
    public int G_Maxgranade;
    public int G_amountgranade;
    public TextMeshProUGUI G_amountTxt;

    private PlayerController player;
    public Animator anim;
   


    private void Start()
    {
        G_amountgranade = G_Maxgranade;

        N_T = nextTime;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        G_amountTxt.SetText(G_amountgranade + "X");
    }

    private void Update()
    {
        G_amountTxt.SetText(G_amountgranade + "X");


        if (Input.GetKeyDown(KeyCode.Mouse1) && G_amountgranade > 0 && N_T<=0)
        {
            G_amountgranade--;
            anim.SetBool("Granade", true);
            Jogar = true;
            N_T = nextTime;

        }
        else
        {
            N_T -= Time.deltaTime;
          
        }

        if (N_T<=0 && Jogar)
        {
            GranadeClone();
            Jogar = false;
            anim.SetBool("Granade", false);
        }
       
     
    }

   
    public void GranadeClone()
    {
        GameObject clone = Instantiate(granade, pointShootGranade.position, Quaternion.identity);
        clone.GetComponent<GranadePlayer>().damage = G_damage;
        clone.GetComponent<Rigidbody2D>().velocity = (transform.up * 40);
        clone.GetComponent<Rigidbody2D>().velocity = (transform.right * G_bulletvelocity);

    }
}
