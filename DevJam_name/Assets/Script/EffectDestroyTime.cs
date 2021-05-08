using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestroyTime : MonoBehaviour
{
    public int lifeTime;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
    
