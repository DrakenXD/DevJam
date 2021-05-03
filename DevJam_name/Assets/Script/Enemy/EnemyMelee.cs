using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : EnemyController
{

    public override void FollowTarget()
    {
        rb.velocity = transform.right * speed;
        if (transform.position.x < target.position.x)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else if (transform.position.x > target.position.x)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
    }
    public override void Attack()
    {
        if (N_T <= 0)
        {

            target.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
            N_T = nextAttack;
        }
        else
        {
            N_T -= Time.deltaTime;
        }
    }
}
