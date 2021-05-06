using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponController : MonoBehaviour
{
    public GameObject bullet;
    public Transform pointShoot;
    [Header("Stats")]
    public float damage;
    public float bulletvelocity;
    public float nextShot;
    private float N_S;

    [Header("Ammunition")]
    public int Maxbullet;
    public int amountbullets;
    public TextMeshProUGUI amountTxt;


    [Header("Reload")]
    public float timetoreload;
    private float T_T_R;

    private PlayerController player;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        amountbullets = Maxbullet;

        T_T_R = timetoreload;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();



        amountTxt.SetText(amountbullets + " /" + Maxbullet);
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    public void Shoot()
    {
        if (Input.GetKey(KeyCode.Mouse0) && N_S <= 0 && amountbullets > 0)
        {
            amountbullets--;
            BulletClone();
            N_S = nextShot;
            anim.SetBool("activate", true);
            amountTxt.SetText(amountbullets+" /"+Maxbullet);
        }
        else
        {
            anim.SetBool("activate", false);
            N_S -= Time.deltaTime;
        }


        if (amountbullets <= 0)
        {
            if (T_T_R <= 0)
            {
                amountbullets = Maxbullet;
                T_T_R = timetoreload;
                amountTxt.SetText(amountbullets + " /" + Maxbullet);
                anim.SetBool("activate", true);
            }
            else
            {
                T_T_R -= Time.deltaTime;
            }
        }
    }

    public void BulletClone()
    {
        GameObject clone= Instantiate(bullet,pointShoot.position,Quaternion.identity);
        clone.GetComponent<BulletController>().damage = damage;
        clone.GetComponent<Rigidbody2D>().velocity=(transform.right * bulletvelocity);

    }
}
