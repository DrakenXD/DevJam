using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowDown : MonoBehaviour
{
    public float velocityDown;
    public static float velocitydata;

    private void Update()
    {
        if (velocitydata < velocityDown)
        {
            velocitydata += 0.1f;
        }

        transform.Translate(Vector2.down* velocitydata * Time.deltaTime);

        if (transform.position.y <= -30)
        {
            transform.position = new Vector3 (transform.position.x, 30,transform.position.z);
        }
    }
}
