using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  

    public Vector2 movement;
    public bool move;
    public bool canmove;
    public int amountjump;
    public bool isJumping;
    public LayerMask whatisground;


    [Header("ShootController")]
    public float MaxAmmuntion;
    [SerializeField]protected float Ammuntion;
    public bool isshooting;
    public int MaxIndexBullet;
    protected int IndexBullet;
    public float delayNextShoot;
    [SerializeField] protected float D_N_S;
    public float TimeToShoot;
    [SerializeField] protected float T_T_S;
    public bool inputShoot;

    [Header("ReloadWeapon")]
    public GameObject ReloadIndicator;
    public bool IsReloading;
    public float TimeToRecharge;
    protected float T_T_R;

    [Header("GravityController")]
    public float gravity;
    public float timetoGravity;
    protected float T_T_G;

    [Header("          WallSlide")]
    public float wallSlideSpeed;
    public float walljumprforce;
    public int facedir = 1;
    public Vector2 walljumpdir;
    public bool isWallSliding;

    [Header("StopMove")]
    public float Stopmove = .3f;

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
    public PlayerUI UI;

    protected InputPlayer input;


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

        UI.TextBullet(Ammuntion, MaxAmmuntion);

        T_T_R = TimeToRecharge;

        T_T_S = 0;
        
        D_N_S = 0;   
    }
    // Update is called once per frame
    void Update()
    {
        if (IsDead())
        {
            gameObject.SetActive(false);
        }
        else
        {
            if (canmove) Move();

            if (canmove) Shooting();

            JumpControler();
        }
    }
    private void FixedUpdate()
    {
        WallCheck();
        GroundCheck();
    }

    public void Spawn()
    {

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement.x = context.ReadValue<float>();
    }
    public void OnShooting(InputAction.CallbackContext context)
    {
        inputShoot = context.ReadValueAsButton();

    }
    public void OnJump(InputAction.CallbackContext context)
    {
        isJumping = context.ReadValueAsButton();
        
    }
    public void Shooting()
    {
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
                ReloadIndicator.SetActive(false);
                Ammuntion = MaxAmmuntion;
                UI.TextBullet(Ammuntion, MaxAmmuntion);
                T_T_R = TimeToRecharge;
                IsReloading = false;
            }
            else
            {
                T_T_R -= Time.deltaTime;
                ReloadIndicator.SetActive(true);
            }

        }


        if (isshooting)
        {


            if (IndexBullet > 0)
            {
                if (D_N_S <= 0)
                {
                    D_N_S = delayNextShoot;

                    anim.animUI.SetBool("Activate", true);

                    IndexBullet--;
                    Ammuntion--;

                    UI.TextBullet(Ammuntion, MaxAmmuntion);

                    weapon.Shoot(stats.damage, facedir);

                    if (Ammuntion <= 0) IsReloading = true;
                }
                else
                {
                    

                    D_N_S -= Time.deltaTime;
                }
                    

            }
            else
            {
                isshooting = false;

                anim.animUI.SetBool("Activate", false);

                IndexBullet = MaxIndexBullet;
            }

            if (!move)
            {
                anim.ChangeAnimatorPlayer("Shoot");
            }
            else if (move)
            {
                anim.ChangeAnimatorPlayer("MoveShoot");
            }
        }




    }
    public void TakeDamage(float dmg)
    {
        stats.life -= dmg;

        UI.BarLife(stats.life, stats.maxlife);

     

        if (IsDead()) Debug.Log("Morrue");



    }

    public bool IsDead()
    {
        return stats.life <= 0;
    }
    public void Move()
    {
         

        rb.velocity = new Vector2(movement.x * stats.speed, rb.velocity.y);

        if (isWallSliding)
        {
            if (rb.velocity.y < -wallSlideSpeed) ;
            {

                rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);
            }
        }

        if (movement.x != 0)
        {
            if (!isshooting) anim.ChangeAnimatorPlayer("Move"); ;
            move = true;
        }
        else move = false;

        if (movement.x > 0.1f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            facedir = 1;
        }
        else if (movement.x < -0.1f)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            facedir = -1;
        }
        else
        {
            if (!isshooting) anim.ChangeAnimatorPlayer("Idle");
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

    public void StopMoveTime()
    {

       

        if (!canmove)
        {
            if (Stopmove <= 0)
            {
                transform.localScale = Vector2.one;

                canmove = true;
                Stopmove = .5f;
            }
            else
            {
                
                Stopmove -= Time.deltaTime;
                transform.localScale = transform.localScale.x == 1 ? new Vector2(-1, 1) : Vector2.one;
            }
        }

        
    }
    public void JumpControler()
    {

        if (amountjump > 0 && !isWallSliding && isJumping)
        {
            rb.velocity = Vector2.zero;

            amountjump--;

            rb.AddForce(Vector2.up * stats.jumpheight, ForceMode2D.Impulse);

        }
        else if (isWallSliding && isJumping)
        {
            Vector2 ForceJump = new Vector2(walljumprforce * walljumpdir.x * -facedir, walljumprforce * walljumpdir.y);

            rb.velocity = Vector2.zero;

            rb.AddForce(ForceJump, ForceMode2D.Impulse);

            //StartCoroutine("StopMove");

            canmove = false;
        }

        StopMoveTime();

        if (IsGrounded) amountjump = 1;
    }
    public void GroundCheck()
    {
        IsGrounded = Physics2D.OverlapCircle(G_Check.position, G_distance, whatisground);

        if (!IsGrounded && !IsWall)
        {
            if (T_T_G <= 0)
            {
                rb.velocity += Vector2.down * gravity;
            }
            else
            {
                T_T_G -= Time.deltaTime;
            }
        }

        if (IsGrounded || IsWall) T_T_G = timetoGravity;
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
        Gizmos.DrawLine(W_Check.position,new Vector3(W_Check.position.x + W_distance, W_Check.position.y,0));
        Gizmos.DrawWireSphere(G_Check.position,G_distance);
    }
}
