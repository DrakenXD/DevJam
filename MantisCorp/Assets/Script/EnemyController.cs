using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyStats stats;
    public Stage state;

    [Header("Follow Enemy")]
    public bool targetinlineRight;
    public float F_distanceRight;
    public bool targetinlineLeft;
    public float F_distanceLeft;
    public bool Isfollowing;
    public LayerMask targetlayer;



    [Header("          DistanceToTarget")]
    public Transform target;
    public float maxdistance;
    public float attackdistance;
    public float stopdistance;
    public float distance;


    private float TimeToSearch =2f;
    private float T_T_S;

    

    // Update is called once per frame
    void Update()
    {
        StateController();
    }

    public virtual void StateController()
    {
        if (state == Stage.Dead)
        {
            state = Stage.Dead;
        }
        else
        {
            if (targetinlineLeft || targetinlineRight)
            {

                SearchTarget();



                if (distance > stopdistance)
                {
                    if (distance < attackdistance)
                    {
                        state = Stage.Attack;
                    }
                    else
                    {
                        Isfollowing = true;
                        state = Stage.Follow;
                    }
                }
                else
                {
                    state = Stage.Idle;
                    Isfollowing = false;
                }
                

            }
        }

        TargetInLine();

        switch (state)
        {
            case Stage.Idle:
                FollowTarget(transform.position);
                break;
            case Stage.Follow:
                FollowTarget(target.position);
                break;
            case Stage.Patrol:
                break;
            case Stage.Attack:
                FollowTarget(transform.position);
                break;
            case Stage.Dead:
                break;

        }

        Debug.Log(state);
    }

    public enum Stage
    {
        Idle,
        Patrol,
        Follow,
        Attack,
        Dead,
    }
    public void FollowTarget(Vector3 _pos)
    {
        transform.position = Vector2.MoveTowards(transform.position, _pos, stats.speed * Time.deltaTime);
    }
    private void TargetInLine()
    {
        targetinlineRight = Physics2D.Raycast(transform.position, transform.right, F_distanceRight, targetlayer); 
        targetinlineLeft = Physics2D.Raycast(transform.position, transform.right, F_distanceLeft, targetlayer);
    }
    protected void SearchTarget()
    {
        GameObject[] Targets = GameObject.FindGameObjectsWithTag("Player");

        float shortestDistance = Mathf.Infinity;

        GameObject nearestTarget = null;

        foreach (GameObject Target in Targets)
        {
            float distancetoTarget = Vector2.Distance(transform.position, Target.transform.position);

            if (distancetoTarget < shortestDistance)
            {
                shortestDistance = distancetoTarget;
                distance = shortestDistance;
                nearestTarget = Target;
            }
        }

        if (nearestTarget != null && shortestDistance <= maxdistance)
        {
            target = nearestTarget.transform;
        }

        if (target == null)
        {
            return;
        }
        
    }
    public void TakeDamage(float dmg)
    {
        stats.life -= dmg;

        if (IsDead())
            state = Stage.Dead;
            Destroy(gameObject); 

        Debug.Log(dmg);
    }
    public bool IsDead()
    {
        return stats.life < 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + F_distanceRight, transform.position.y, 1));
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + F_distanceLeft, transform.position.y, 1));

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackdistance);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, stopdistance);
    }
}
