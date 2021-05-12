using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 movement;
    public bool canmove;
    public int amountjump;
    public LayerMask whatisground;
    public bool isshooting;
    public bool inputShoot;

    [Header("          WallSlide")]
    public float wallSlideSpeed;
    public float walljumprforce;
    public int facedir = 1;
    public Vector2 walljumpdir;
    public bool isWallSliding;

    [Header("          WallCheck")]
    public Transform W_Check;
    public float W_distance;
    public bool IsWall;

    [Header("          WallCheck")]
    public Transform G_Check;
    public float G_distance;
    public bool IsGrounded;

    [Header("          Components")]
    public Rigidbody2D rb;
    public PlayerStats stats;
    public WeaponController weapon;
    public AnimatorController anim;
    private InputPlayer input;

    private void Awake()
    {
        input = new InputPlayer();

        
    }
    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        
        if(canmove || isshooting) Move();
        Shooting();
        JumpControler();
    }
    private void FixedUpdate()
    {
        WallCheck();
        GroundCheck();
    }
    public void Shooting()
    {
        inputShoot = input.Player.PlayerShoot.triggered;
        if (inputShoot)
        {
            isshooting = true;
            if (isshooting)
            {
                StartCoroutine("ShootDelay");
                anim.ChangeAnimator("Shoot");
                weapon.Shoot(stats.damage, facedir);
            }
        }
    }
    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(.3f);
        isshooting = false;
    }
    public void Move()
    {
        movement.x = input.Player.PlayerMove.ReadValue<float>();
        //movement.x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movement.x * stats.speed, rb.velocity.y);

        if (isWallSliding)
        {
            if (rb.velocity.y < -wallSlideSpeed);
            {

                rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);
            }
        }

        if (movement.x > 0.1f)
        {
            transform.eulerAngles = new Vector3(0,0,0);
            facedir = 1;
        }else if (movement.x < -0.1f)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            facedir = -1;
        }
        else
        {
            anim.ChangeAnimator("Idle");
        }
    }
    IEnumerator StopMove()
    {
        canmove = false;

        transform.localScale = transform.localScale.x == 1 ? new Vector2(-1,1) : Vector2.one;
        
        yield return new WaitForSeconds(.3f);

        transform.localScale = Vector2.one;

        canmove = true;
    }
    public void JumpControler()
    {
        bool isjump = input.Player.PlayerJump.triggered;
        if (isjump)
        {
            if (amountjump > 0 && !isWallSliding)
            {
                rb.velocity = Vector2.zero;

                amountjump--;

                rb.AddForce(Vector2.up * stats.jumpheight, ForceMode2D.Impulse);
            } else if (isWallSliding) 
            { 
                Vector2 ForceJump = new Vector2(walljumprforce * walljumpdir.x * -facedir, walljumprforce * walljumpdir.y);
                
                rb.velocity = Vector2.zero;

                rb.AddForce(ForceJump, ForceMode2D.Impulse);

                StartCoroutine("StopMove");
            }
        }
    
        if (IsGrounded) amountjump = 1;
    }
    public void GroundCheck()
    {
        IsGrounded = Physics2D.OverlapCircle(G_Check.position, G_distance, whatisground);
        
      
    }
    public void WallCheck()
    {
        IsWall = Physics2D.Raycast(W_Check.position, transform.right, W_distance, whatisground);

        if (IsWall && !IsGrounded && movement.x != 0 && rb.velocity.y < 0)
        {
            isWallSliding=true;
        }
        else
        {
            isWallSliding = false;
        }
    }
 

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(W_Check.position,new Vector3(W_Check.position.x+ W_distance, W_Check.position.y,0));
        Gizmos.DrawWireSphere(G_Check.position,G_distance);
    }
}
