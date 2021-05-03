using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{


    private Vector2 movement;


    [Header("JumpController")]
    public bool IsJumping;

    [Header("WallCheck")]
    public Transform W_Check;
    public Vector2 W_radius;
    public LayerMask W_layer;
    public bool IsWall;
    [Header("GroundCheck")]
    public Transform G_check;
    public float G_radius;
    public LayerMask G_layer;
    public bool IsGround;
    [Header("Gravity")]
    public float gravity = 9f;


    private Rigidbody2D rb;
    private PlayerStats stats;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            TakeDamage(10);
        }

        Move();
        Jump();
        GrabWall();
        W_G_Check();
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
        if (Input.GetButton("Jump") && stats.extrajumps > 0)
        {
            movement.y = stats.jumpheight;
            
         
            stats.extrajumps--;
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
            movement.y = Input.GetAxis("Vertical");
           

        }


    }
    public void W_G_Check()
    {
        IsGround = Physics2D.OverlapCircle(G_check.position, G_radius, G_layer);
        IsWall = Physics2D.OverlapBox(W_Check.position, W_radius, W_layer);
    }
    private void Gravity()
    {
       



        if (IsGround)
        {
            movement.y = 0;
          
            IsJumping = false;
        }

        if (!IsGround || !IsWall)
        {
            movement.y -= 2*Time.deltaTime;
            
        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(G_check.position, G_radius);
        Gizmos.DrawWireCube(W_Check.position, W_radius);
    }
}


