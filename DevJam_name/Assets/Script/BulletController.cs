using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float damage;
    public float lifetime;
    private void Start()
    {
        Destroy(gameObject,lifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyController>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Block"))
        {
            collision.gameObject.GetComponent<BlockController>().TakeDamage(1);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Wall"))
        {

            Destroy(gameObject);
        }

    }
}
