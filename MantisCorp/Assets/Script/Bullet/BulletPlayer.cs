using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    public float Bulletdamage;
    public float DamageAdditional;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            float dmg = Bulletdamage + DamageAdditional;

            collision.gameObject.GetComponent<EnemyController>().TakeDamage(dmg);
            
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Shield"))
        {
            collision.gameObject.GetComponent<ShieldController>().TakeDamage();

            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Ground") )
        {


            Destroy(gameObject);
        }
    }
}
