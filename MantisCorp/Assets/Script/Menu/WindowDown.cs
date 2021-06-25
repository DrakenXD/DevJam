using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowDown : MonoBehaviour
{
    public float MaxVelocity;
    public float SpeeDown;
    public static float velocitydata;

    private void Update()
    {
        if (velocitydata < MaxVelocity)
        {
            velocitydata += SpeeDown;
        }

        transform.Translate(Vector2.down* velocitydata * Time.deltaTime);

        if (transform.position.y <= -30)
        {
            transform.position = new Vector3 (transform.position.x, 30,transform.position.z);
        }
    }
}
