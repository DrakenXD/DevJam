using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bullet;
    public Transform pointShoot;
    public Vector2 ShootDir;
    public float bulletvelocity;



   
    public void Shoot(float _dmg, int dir)
    {
        GameObject clone = Instantiate(bullet, pointShoot.position, pointShoot.rotation);
        
        Vector2 force = new Vector2(ShootDir.x * bulletvelocity * dir, ShootDir.y * bulletvelocity);

        clone.GetComponent<BulletPlayer>().DamageAdditional += _dmg;
        
        clone.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
    }
}
