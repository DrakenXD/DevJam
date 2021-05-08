using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSingle : WeaponController
{
    public override void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && W_N_S <= 0 && W_amountbullets > 0)
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
}
