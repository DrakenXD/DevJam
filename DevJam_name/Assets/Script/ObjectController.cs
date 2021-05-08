using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public float life;
    public GameObject[] prefabBuff;


    
    public void TakeDamage(float dmg)
    {
        life -= dmg;
        if (Isbroken())
        {
            DropBuff();
            Destroy(gameObject);
        }
    }

    public bool Isbroken()
    {
        if (life > 0) return true;
        return false;
    }

    public void DropBuff()
    {
        int index = Random.Range(0, prefabBuff.Length);
        Instantiate(prefabBuff[index],transform.position,Quaternion.identity);
    }
}
