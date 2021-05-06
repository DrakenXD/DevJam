using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed;
    float lastspeed;


    // Update is called once per frame
    void Update()
    {
        if (lastspeed < speed)
        {
            lastspeed += .055f;
        }
        else
        {
            lastspeed = speed;
        }

        transform.Translate(Vector3.down * lastspeed);
       



        if (transform.position.y <= 0)
        {
            transform.position = new Vector2(transform.position.x,22);
        }

    }
}
