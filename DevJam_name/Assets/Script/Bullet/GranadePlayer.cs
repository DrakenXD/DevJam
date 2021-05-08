using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadePlayer : Granade
{
    public override void Explode()
    {
        Collider2D[] hitinfo = Physics2D.OverlapCircleAll(transform.position, radius, layer);
        Effect();
        foreach (Collider2D hit in hitinfo)
        {
            Vector2 dir = hit.transform.position - transform.position;

            hit.GetComponent<Rigidbody2D>().AddForce(dir * force, ForceMode2D.Impulse);

            if (hit.gameObject.CompareTag("Enemy"))
            {
                hit.gameObject.GetComponent<EnemyController>().TakeDamage(damage);
            
                Destroy(gameObject);
            }
            if (hit.gameObject.CompareTag("Object"))
            {
                hit.gameObject.GetComponent<ObjectController>().TakeDamage(damage);
               
                Destroy(gameObject);
            }
        }
    }


    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Explode();
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Object"))
        {
            Explode();
            Destroy(gameObject);
        }
    }
}
