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

    private int NextSave;

    // Start is called before the first frame update
    void Start()
    {
        _Addlife += 50;

        NextSave = PlayerPrefs.GetInt("NextSave");

        if (NextSave == 1)
        {
            //colocar os stats salvos
            maxlife = PlayerPrefs.GetFloat("maxlife");
            maxspeed = PlayerPrefs.GetFloat("maxspeed");
            maxjumpheight = PlayerPrefs.GetFloat("maxjumpheight");
            maxdamage = PlayerPrefs.GetFloat("maxdamage");
        }
        else
        {
            NextSave++;

            PlayerPrefs.SetInt("NextSave",NextSave);
        }
     


        //adicionando bonus
        maxlife += _Addlife;
        maxspeed += _Addspeed;
        maxjumpheight += _Addjumpheight;
        maxdamage += _Adddamage;

       
        //salvar stats
        PlayerPrefs.SetFloat("maxlife",maxlife);
        PlayerPrefs.SetFloat("maxspeed", maxspeed);
        PlayerPrefs.SetFloat("maxjumpheight", maxjumpheight);
        PlayerPrefs.SetFloat("maxdamage", maxdamage);

        //padrão
        life = maxlife;
        speed = maxspeed;
        jumpheight = maxjumpheight;
        damage = maxdamage;
    }

    
}
