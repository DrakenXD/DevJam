using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : Bulletenemy
{
    public float timetoexplode;
    public float radius;
    public LayerMask layer;
    public float force;
    
  
    void Update()
    {
        if (timetoexplode <= 0)
        {
            Explode();
        }
        else
        {
            timetoexplode -= Time.deltaTime;
        }
    }

    public virtual void Explode()
    {
        Collider2D[] hitinfo = Physics2D.OverlapCircleAll(transform.position, radius, layer);
        foreach (Collider2D hit in hitinfo)
        {
            Vector2 dir = hit.transform.position - transform.position;

            hit.GetComponent<Rigidbody2D>().AddForce(dir * force,ForceMode2D.Impulse);

            if (hit.gameObject.CompareTag("Player"))
            {
                hit.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }

   
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Explode();
            Destroy(gameObject);
        }
   
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
