using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Stats")]
    public float Maxlife;
    private float life;

    public bool rightGround;
    public bool rightWall;
    public bool moveright;

    public Transform G_check;
    public LayerMask G_layer;
    public float G_radius;

    public Transform W_check;
    public LayerMask W_layer;
    public float W_radius;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        life = Maxlife;
    }

    // Update is called once per frame
    void Update()
    {
        rightGround = Physics2D.OverlapCircle(G_check.position,G_radius,G_layer);
        rightWall = Physics2D.OverlapCircle(W_check.position, W_radius, W_layer);

        if (!rightGround)
        {
            if (moveright)
            {
                
                
                transform.localEulerAngles = new Vector3(0, 180, 0);
                moveright = false;
            }
            else
            {
                
                transform.localEulerAngles = new Vector3(0, 0 ,0);
                moveright = true;
            }
        }else if (rightGround && rightWall)
        {
            if (moveright)
            {


                transform.localEulerAngles = new Vector3(0, 180, 0);
                moveright = false;
            }
            else
            {

                transform.localEulerAngles = new Vector3(0, 0, 0);
                moveright = true;
            }
        }

        rb.velocity = transform.right * 5f;

    }
    public void TakeDamage(float dmg)
    {
        life -= dmg;
        if (IsDead()) Destroy(gameObject);
    }

    public bool IsDead()
    {
        if (life <= 0) return true;
        return false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(G_check.position,G_radius);
        Gizmos.DrawWireSphere(W_check.position, W_radius);
    }
}
