using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    [Header("          Shield")]
    public int lifeshield;
    public bool isBroken;

    private void Start()
    {
       
    }

    public void TakeDamage()
    {
        lifeshield -= 1;
        if (lifeshield <= 0)
        {
            gameObject.SetActive(false);
            isBroken = true;
        }
    }
}
