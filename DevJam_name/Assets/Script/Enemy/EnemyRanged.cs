using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : EnemyController
{
    [Header("Weapon")]
    public GameObject bullet;
    public Transform pointShoot;
    public float bulletvelocity;

    public override void Attack()
    {
        if (N_T <= 0)
        {

            GameObject clone = Instantiate(bullet, pointShoot.position, Quaternion.identity);
            clone.GetComponent<BulletController>().damage = damage;
            clone.GetComponent<Rigidbody2D>().velocity = transform.right * bulletvelocity;
            N_T = nextAttack;
        }
        else
        {
            N_T -= Time.deltaTime;
        }
    }
}
