using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryBuffs : MonoBehaviour
{
    public static InventoryBuffs instance;

    private void Awake()
    {
        instance = this;
    }

    public WeaponController weaponstats;
    public PlayerStats playerstats;
    public PlayerController playercontroller;
    public GranadeController granade;

    public List<Buff> buffs = new List<Buff>();

    public delegate void OnBuffChanged();
    public OnBuffChanged OnBuffChangedCallBack;
  

    private void Update()
    {
        if (buffs.Count > 0)
        {

            for (int i = 0; i < buffs.Count; i++)
            {
                if (buffs[i].usage_time > 0)
                {
                    buffs[i].usage_time -= Time.deltaTime;
               
                  
                }
                else
                {
                    RemoveBuff(buffs[i]);
                }
            }
        }
    }
    public void AddBuff(Buff _buff)
    {
        if (buffs.Contains(_buff))
        {
            for (int i = 0; i < buffs.Count; i++) 
            {
                if (buffs[i]==_buff)
                {
                    buffs[i].usage_time = _buff.MaxTime;
                }
            }

        }
        else
        {
            buffs.Add(_buff);

            AddBuffsInPlayer(_buff);


            if (OnBuffChangedCallBack != null)
            {
                OnBuffChangedCallBack.Invoke();
            }
        }
    }

    public void AddBuffsInPlayer(Buff _buff)
    {
        if (_buff.buffstats==BuffStats.Speed)
        {
            playerstats.speed += _buff.buffcomponents._Speed;
        }
   
        if (_buff.buffstats == BuffStats.Invincibility)
        {
            playercontroller.invincibility = _buff.buffcomponents._Invincibility;
        }
    
        if (_buff.buffstats == BuffStats.BulletInfinity)
        {
            weaponstats.bulletinfinity = _buff.buffcomponents._BulletInfinity;
            weaponstats.W_amountbullets = 999;
            granade.G_amountgranade = 999;
        }
    
        if (_buff.buffstats == BuffStats.Granade)
        {
            granade.G_amountgranade = _buff.buffcomponents._Granade;
        }

        if (_buff.buffstats == BuffStats.LifeRegen)
        {
            playerstats.life += _buff.buffcomponents._LifeRegen;

            if (playerstats.life > playerstats.Maxlife)
            {
                playerstats.life = playerstats.Maxlife;
            }
        }
    }
    public void RemoveBuffsInPlayer(Buff _buff)
    {
        if (_buff.buffstats == BuffStats.Speed)
        {
            playerstats.speed -= _buff.buffcomponents._Speed;
        }
    
        if (_buff.buffstats == BuffStats.Invincibility)
        {
            playercontroller.invincibility = false;
        }
    
        if (_buff.buffstats == BuffStats.BulletInfinity)
        {
            weaponstats.bulletinfinity = false;
            weaponstats.W_amountbullets = weaponstats.W_Maxbullet;
            granade.G_amountgranade = granade.G_Maxgranade;
        }
    
   
      
    }
    public void RemoveBuff(Buff _buff)
    {
        if (buffs.Contains(_buff))
        {
            for (int i = 0; i < buffs.Count; i++)
            {
                RemoveBuffsInPlayer(_buff);
                buffs.Remove(_buff);

                
            } 
        }
        if (OnBuffChangedCallBack != null)
        {
            OnBuffChangedCallBack.Invoke();
        }
    }
}
