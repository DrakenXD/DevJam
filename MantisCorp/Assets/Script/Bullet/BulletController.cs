using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float damage;
    public string nameEnemy;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyController>().TakeDamage(damage);
            Debug.Log("dsadas");
        }

        if (collision.gameObject.CompareTag("Ground") )
        {
            Destroy(gameObject);
        }
    }
}
