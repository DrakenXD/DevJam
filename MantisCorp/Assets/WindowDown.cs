using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowDown : MonoBehaviour
{
    public float velocityDown;
    private float velocitydata;

    private void Update()
    {
        if (velocitydata < velocityDown)
        {
            velocitydata += 0.050f;
        }

        transform.Translate(Vector2.down* velocitydata * Time.deltaTime);

        if (transform.position.y <= -15)
        {
            transform.position = new Vector3 (0,15,transform.position.z);
        }
    }
}
