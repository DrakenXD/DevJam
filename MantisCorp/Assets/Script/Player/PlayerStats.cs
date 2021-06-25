using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStats : MonoBehaviour
{
    [Header("Start Stats")]
    public float maxlife;
    public float maxspeed;
    public float maxjumpheight;
    public float maxdamage;

    [Header("Update Stats")]
    public float life;
    public float speed;
    public float jumpheight;
    public float damage;

    public static float _Addlife;
    public static float _Addspeed;
    public static float _Addjumpheight;
    public static float _Adddamage;

    // Start is called before the first frame update
    void Start()
    {
       

        //adicionando bonus
        maxlife += _Addlife;
        maxspeed += _Addspeed;
        maxjumpheight += _Addjumpheight;
        maxdamage += _Adddamage;

        //padrão
        life = maxlife;
        speed = maxspeed;
        jumpheight = maxjumpheight;
        damage = maxdamage;
    }

    
}
