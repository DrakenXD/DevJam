using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletenemy : MonoBehaviour
{

    public float damage;
    public float lifetime;
    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
   
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Wall"))
        {

            Destroy(gameObject);
        }
    }
}
