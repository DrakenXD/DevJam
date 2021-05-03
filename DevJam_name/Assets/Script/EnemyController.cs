using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Stats")]
    public float Maxlife;
    private float life;


    // Start is called before the first frame update
    void Start()
    {
        life = Maxlife;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
