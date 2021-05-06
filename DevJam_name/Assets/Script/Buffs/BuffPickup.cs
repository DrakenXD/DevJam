using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffPickup : MonoBehaviour
{
    public Buff buff;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            buff.usage_time = buff.MaxTime;
            InventoryBuffs.instance.AddBuff(buff);
            Destroy(gameObject);
        }
    }
}
