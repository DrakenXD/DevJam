using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponController : MonoBehaviour
{
    public GameObject bullet;
    public Transform pointShoot;
    public bool bulletinfinity;

    [Header("Stats weapon")]
    public float W_damage;
    public float W_bulletvelocity;
    public float W_nextShot;
    protected float W_N_S;

    [Header("Ammunition Weapon")]
    public int W_Maxbullet;
    public int W_amountbullets;
    public TextMeshProUGUI W_amountTxt;

    [Header("Reload Weapon")]
    public float W_timetoreload;
    protected float W_T_T_R;

   



    protected PlayerController player;
    public Animator playeranim;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        W_amountbullets = W_Maxbullet;
       
        W_T_T_R = W_timetoreload;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();



        W_amountTxt.SetText(W_amountbullets + " /" + W_Maxbullet);
     
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();


        W_amountTxt.SetText(W_amountbullets + " /" + W_Maxbullet);
    }
    public virtual void Shoot()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            playeranim.SetBool("Shoot", true);
            if (W_N_S <= 0 && W_amountbullets > 0)
            {
                W_amountbullets--;
                BulletClone();
                W_N_S = W_nextShot;
               
                anim.SetBool("activate", true);
            }
            W_N_S -= Time.deltaTime;
        }
        else
        {
            playeranim.SetBool("Shoot", false);
            anim.SetBool("activate", false);
            W_N_S -= Time.deltaTime;
        }


        if (W_amountbullets <= 0)
        {
            if (W_T_T_R <= 0)
            {
                W_amountbullets = W_Maxbullet;
                W_T_T_R = W_timetoreload;
                
                anim.SetBool("activate", true);
            }
            else
            {
                W_T_T_R -= Time.deltaTime;
            }
        }


    }

    public virtual void BulletClone()
    {
        GameObject clone= Instantiate(bullet,pointShoot.position,transform.rotation);
        clone.GetComponent<BulletController>().damage = W_damage;
        clone.GetComponent<Rigidbody2D>().velocity=(transform.right * W_bulletvelocity);

    }

}
