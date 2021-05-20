using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("          Enemy Stats")]
    public float Maxlife;
    public float Maxspeed;
    public float Maxjumpheight;

    [Header("          Enemy Update")]
    public float life;
    public float speed;
    public float jumpheight;

    // Start is called before the first frame update
    void Start()
    {
        life = Maxlife;
        
        speed = Maxspeed;

        jumpheight = Maxjumpheight;
    }

    
}
