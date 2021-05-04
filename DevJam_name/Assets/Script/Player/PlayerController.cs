﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{


    [SerializeField]private Vector2 movement;


    [Header("JumpController")]
    public bool IsJumping;
    [Header("Timing Attack")]
    public float nextAttak;
    private float N_T; 

    [Header("AttackController")]
    public Transform A_check;
    public float A_radius;
    public LayerMask A_layer;

    [Header("WallCheck")]
    public Transform W_Check;
    public Vector2 W_radius;
    public LayerMask W_layer;
    public bool IsWall;

    [Header("GroundCheck")]
    public Transform G_check;
    public Vector2 G_radius;
    public LayerMask G_layer;
    public bool IsGround;

    [Header("Gravity")]
    public float gravity = 9f;
    public float timegravity;
    private float T_G;


    private Rigidbody2D rb;
    private PlayerStats stats;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<PlayerStats>();

        T_G = timegravity;
    }

    // Update is called once per frame
    void Update()
    {
        

        Move();
        Jump();
        Attack();
        GrabWall();
        W_G_Check();
    }

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (N_T <= 0)
            {
                Collider2D[] hitinfo = Physics2D.OverlapCircleAll(A_check.position, A_radius, A_layer);
                foreach (Collider2D hit in hitinfo)
                {
                    if (hit.gameObject.CompareTag("Enemy"))
                    {
                        hit.gameObject.GetComponent<EnemyController>().TakeDamage(1);
                    }
                    if (hit.gameObject.CompareTag("Shield"))
                    {
                        hit.gameObject.GetComponent<ShieldController>().TakeDamage(1);
                    }
                }
                N_T = nextAttak;
            }
            
        }
        else N_T -= Time.deltaTime;

    }
    private void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");


        

        if (movement.x > 0.1f)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
           
        }
        else if (movement.x < -0.1f)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
           
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        rb.velocity = movement * stats.speed;
    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && stats.extrajumps > 0)
        {

            T_G = timegravity;

            movement.y = stats.jumpheight;
         
           

            IsJumping = true;
            stats.extrajumps--;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            IsJumping = false;
        }



        if (IsGround || IsWall)
        {
            stats.extrajumps = stats.Maxextrajumps;
        }
    }
    public void TakeDamage(float dmg)
    {
        stats.life -= dmg;
        if (IsDead())
        {
            //animação de morte
            
        }
    }
    public bool IsDead()
    {
        if (stats.life <= 0)
        {
            stats.life = 0;
            return true;
        }
        else return false;
    }
    private void FixedUpdate()
    {
        Gravity();
    }
    private void GrabWall()
    {
        if (IsWall)
        {
            if (Input.GetAxis("Vertical") > .1f)
            {
                movement.y = .5f;
            }else if (Input.GetAxis("Vertical") < -.1f)
            {
                movement.y = -.5f;
            }
            else
            {
                movement.y = 0;
            }
            
           

        }


    }
    public void W_G_Check()
    {
        IsGround = Physics2D.OverlapBox(G_check.position, G_radius, G_layer);
        IsWall = Physics2D.OverlapBox(W_Check.position, W_radius, W_layer);
    }
    private void Gravity()
    {
       



        if ( !IsWall && !IsGround)
        {
            if (T_G<=0)
            {
                movement.y = -Time.deltaTime * gravity;

                if (IsGround)
                {
                    movement.y = 0;
                }

            }
            else
            {
                T_G -= Time.deltaTime;
            }

        }
        else
        {
            T_G = timegravity;
        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(G_check.position, G_radius);
        Gizmos.DrawWireCube(W_Check.position, W_radius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(A_check.position, A_radius);
    }
}


