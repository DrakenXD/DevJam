using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : EnemyController
{
    [Header("Bullet Stats")]
    public GameObject bullet;
    public Transform PointShoot;
    public float bulletVelocity;

    public override void FollowTarget(Vector3 _pos)
    {
        base.FollowTarget(_pos);

        anim.SetBool("IsMove", Isfollowing);

        //anim.ChangeAnimator("Move");
    }
    public override void LoadingAttack()
    {
      

        anim.SetBool("IsShooting",IsAttacking);

        //anim.ChangeAnimator("Shooting");
    }
    public override void Attack()
    {
       

        GameObject clone = Instantiate(bullet,PointShoot.position,PointShoot.rotation);
        clone.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletVelocity,ForceMode2D.Impulse);

        IsAttacking = false;

        anim.SetBool("IsShooting", false);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
}
