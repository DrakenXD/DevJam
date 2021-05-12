using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject lent;
    public Vector2 movement;
    public bool move;
    public bool canmove;
    public int amountjump;
    public LayerMask whatisground;


    [Header("ShootController")]
    public float MaxAmmuntion;
    [SerializeField]protected float Ammuntion;
    public bool isshooting;
    public int MaxIndexBullet;
    protected int IndexBullet;
    public float delayNextShoot;
    protected float D_N_S;
    public float TimeToShoot;
    private float T_T_S;
    public bool inputShoot;
    [Header("ReloadWeapon")]

    public bool IsReloading;
    public float TimeToRecharge;
    protected float T_T_R;


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
    protected InputPlayer input;

    private bool test;
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

    private void Start()
    {
        Ammuntion = MaxAmmuntion;
    }
    // Update is called once per frame
    void Update()
    {
        bool visionx = input.Player.PlayerVisionNight.triggered;
        if (visionx && !test)
        {
            test = true;
            lent.SetActive(true);
        }else if (visionx && test)
        {
            test = false;
            lent.SetActive(false);
        }

        if (canmove) Move();
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

        if (!IsReloading)
        {
            if (inputShoot && !isshooting && T_T_S <= 0)
            {
                T_T_S = TimeToShoot;
                isshooting = true;

            }
            else T_T_S -= Time.deltaTime;
        }
        else
        {
            if (T_T_R <= 0)
            {
                Ammuntion = MaxAmmuntion;
                T_T_R = TimeToRecharge;
                IsReloading = false;
            }else T_T_R -= Time.deltaTime;

        }

        if (!move && isshooting)
        {
            anim.ChangeAnimator("Shoot");
        }
        else if (move && isshooting)
        {
            anim.ChangeAnimator("MoveShoot");
        }

        if (isshooting)
        {
            if (IndexBullet > 0)
            {
                if (D_N_S <= 0)
                {
                    D_N_S = delayNextShoot;
                    IndexBullet--;
                    Ammuntion--;
                    weapon.Shoot(stats.damage, facedir);

                    if (Ammuntion <= 0) IsReloading = true;
                }
                else D_N_S -= Time.deltaTime;

            }
            else
            {
                isshooting = false;
               
               
         
                IndexBullet = MaxIndexBullet;
            }
        }




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

        if (movement.x != 0)
        {
            if (!isshooting) anim.ChangeAnimator("Move"); ;
            move = true;
        }
        else move = false;

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
            if(!isshooting) anim.ChangeAnimator("Idle");
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
