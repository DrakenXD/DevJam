using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Stats")]
    public float Maxlife;
    protected float life;
    public float damage;
    public float speed;

    public bool rightGround;
    public bool rightWall;
    public bool moveright;

    public State state;

    [Header("Vision")]
    public float distance;
    protected Transform target;
    public float dis_target_sighted;
    public float dis_Attack_Area;
    public GameObject sighted;

    [Header("Attack")]
    public float nextAttack;
    protected float N_T;

   

    [Header("GroundCheck")]
    public Transform G_check;
    public LayerMask G_layer;
    public float G_radius;

    [Header("WallCheck")]
    public Transform W_check;
    public LayerMask W_layer;
    public float W_radius;

    protected Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        life = Maxlife;
    }

    // Update is called once per frame
    void Update()
    {

        Vision();
        EnumStates();
    }
    public virtual void Vision()
    {
        distance = Vector2.Distance(transform.position,target.position);
        if (distance <= dis_target_sighted)
        {
            sighted.SetActive(true);
            state = State.Sighted;

            if (distance <= dis_Attack_Area)
            {
                state = State.Attack_Area;
            }

        }
        else
        {
            state = State.Idle;
            sighted.SetActive(false);
            N_T = nextAttack;
        }

    }
    public virtual void EnumStates()
    {
        switch (state)
        {
            case State.Idle:
                break;       
            case State.Sighted:
                LookTarget();
                FollowTarget();
                break;
            case State.Attack_Area:
                LookTarget();
                Attack();
                break;

        }
    }
    public virtual void FollowTarget()
    {
        //seguir player
    }
    public enum State
    {
        Idle,
        Sighted,
        Attack_Area,

    }
    public virtual void Attack()
    {
        /*
        if (N_T <= 0)
        {
           
            GameObject clone = Instantiate(bullet, pointShoot.position, Quaternion.identity);
            clone.GetComponent<Rigidbody2D>().velocity = transform.right * bulletvelocity;
            N_T = nextAttack;
        }
        else
        {
            N_T -= Time.deltaTime;
        }
        */
    }
    public void LookTarget()
    {
        if (transform.position.x < target.position.x)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else if (transform.position.x > target.position.x)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
    }
    public void IAPlatform()
    {
        rightGround = Physics2D.OverlapCircle(G_check.position, G_radius, G_layer);
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

                transform.localEulerAngles = new Vector3(0, 0, 0);
                moveright = true;
            }
        }
        else if (rightGround && rightWall)
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
    public virtual void TakeDamage(float dmg)
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

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,dis_target_sighted);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, dis_Attack_Area);
    }
}
