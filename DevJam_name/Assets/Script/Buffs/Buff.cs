using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BuffStats{
    BulletVelocity,
    Speed,
    BulletInfinity,
    Invincibility,
    LifeRegen,
    Granade,
    

}
[System.Serializable]
public class BuffComponents
{
    public float _BulletVelocity;
    public float _Speed;
    public bool _BulletInfinity;
    public bool _Invincibility;
    public float _LifeRegen;
    public int _Granade;

}



[CreateAssetMenu(fileName ="New Buff", menuName ="Inventory/Buff")]
public class Buff : ScriptableObject
{
    new public string name = "New Buff";
    public Sprite icon = null;
    public float MaxTime;
    public float usage_time;
    public bool isDefaultBuff=false;
    public BuffStats buffstats;
    public BuffComponents buffcomponents;
}

