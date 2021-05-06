using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : EnemyController
{
    [Header("Weapon")]
    public GameObject bullet;
    public Transform pointShoot;
    public float bulletvelocity;
    public bool granade;

    public override void Attack()
    {
        if (N_T <= 0)
        {

            GameObject clone = Instantiate(bullet, pointShoot.position, Quaternion.identity);
           
            
          
            if (granade)
            {

                clone.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.right.x,transform.up.y) * distance;
                clone.GetComponent<Bulletenemy>().damage = damage;
            }
            else
            {
                clone.GetComponent<Rigidbody2D>().velocity = transform.right * bulletvelocity;
                clone.GetComponent<Bulletenemy>().damage = damage;
            }
            N_T = nextAttack;
        }
        else
        {
            N_T -= Time.deltaTime;
        }
    }
}
