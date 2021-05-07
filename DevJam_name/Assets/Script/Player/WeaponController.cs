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
    private float W_N_S;

    [Header("Ammunition Weapon")]
    public int W_Maxbullet;
    public int W_amountbullets;
    public TextMeshProUGUI W_amountTxt;

    [Header("Reload Weapon")]
    public float W_timetoreload;
    private float W_T_T_R;

   



    private PlayerController player;
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
    public void Shoot()
    {
        if (Input.GetKey(KeyCode.Mouse0) && W_N_S <= 0 && W_amountbullets > 0)
        {
            W_amountbullets--;
            BulletClone();
            W_N_S = W_nextShot;
            anim.SetBool("activate", true);
           
        }
        else
        {
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

    public void BulletClone()
    {
        GameObject clone= Instantiate(bullet,pointShoot.position,Quaternion.identity);
        clone.GetComponent<BulletController>().damage = W_damage;
        clone.GetComponent<Rigidbody2D>().velocity=(transform.right * W_bulletvelocity);

    }

}
