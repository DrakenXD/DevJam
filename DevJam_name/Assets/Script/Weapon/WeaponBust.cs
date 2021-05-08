using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBust : WeaponController
{
    public bool shoot;
    public float timebust=.1f;
    public int index;
    public override void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && W_N_S <= 0 && W_amountbullets > 0)
        {
            shoot = true;

        }
        else
        {
       
            anim.SetBool("activate", false);
            W_N_S -= Time.deltaTime;
        }

        if (shoot)
        {
            if (timebust <= 0 && index < 3)
            {
                W_amountbullets--;
                BulletClone();
                W_N_S = W_nextShot;
                anim.SetBool("activate", true);
                timebust = .1f;
                index++;
            }
            else
            {
                timebust -= Time.deltaTime;
                if (index >= 3)
                {
                    shoot = false;
                    index = 0;
                }
            }
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
}
