using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Start")]
    public float Maxlife;
    public float Maxspeed;
    public float Maxjumpheight;
    public int Maxextrajumps;


    [Header("Update")]
    public float life;
    public float speed;
    public float jumpheight;
    public int extrajumps;

    void Awake()
    {
        life = Maxlife;
        speed = Maxspeed;
        jumpheight = Maxjumpheight;
        extrajumps = Maxextrajumps;
    }

    
}
