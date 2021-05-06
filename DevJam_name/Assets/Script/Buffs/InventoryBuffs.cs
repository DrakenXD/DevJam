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



            if (OnBuffChangedCallBack != null)
            {
                OnBuffChangedCallBack.Invoke();
            }
        }
    }

    public void RemoveBuff(Buff _buff)
    {
        if (buffs.Contains(_buff))
        {
            for (int i = 0; i < buffs.Count; i++)
            {
                buffs.Remove(_buff);
               
                
            } 
        }
        if (OnBuffChangedCallBack != null)
        {
            OnBuffChangedCallBack.Invoke();
        }
    }
}
