using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed;



    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed*Time.deltaTime);
        if (transform.position.y <= -29)
        {
            transform.position = new Vector2(transform.position.x,29);
        }

    }
}
