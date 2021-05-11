using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 movement;
    public bool canmove;
    public float speed;
    public float jumpheight;
    public int amountjump;

    [Header("WallSlide")]
    public float wallSlideSpeed;
    public float walljumprforce;
    public int facedir =1;
    public Vector2 walljumpdir;
    public bool isWallSliding;
    [Header("WallCheck")]
    public Transform W_Check;
    public float W_distance;
    public bool IsWall;

    [Header("WallCheck")]
    public Transform G_Check;
    public float G_distance;
    public LayerMask whatisground;
    public bool IsGrounded;

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(canmove)Move();
        JumpControler();
    }
    private void FixedUpdate()
    {
        WallCheck();
        GroundCheck();
    }
    public void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (amountjump > 0 && !isWallSliding)
            {
                rb.velocity = Vector2.zero;
                amountjump--;
                rb.AddForce(Vector2.up * jumpheight, ForceMode2D.Impulse);
            }else if (isWallSliding)
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
