using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public int life;
  
    public void TakeDamage(int dmg)
    {
        life -= dmg;
        if (IsDestroy()) Destroy(gameObject);
    }

    public bool IsDestroy()
    {
        if (life <= 0)
        {
            life = 0;
            return true;
        }
        else return false;
    }
}
