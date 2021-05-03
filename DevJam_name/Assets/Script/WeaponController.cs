using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bullet;
    public Transform pointShoot;
    [Header("Stats")]
    public float bulletvelocity;
    public float nextShot;
    private float N_S;

    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && N_S <= 0)
        {
            BulletClone();
            N_S = nextShot;
        }
        else
        {
            N_S -= Time.deltaTime;
        }

    }

    public void BulletClone()
    {
        GameObject clone= Instantiate(bullet,pointShoot.position,Quaternion.identity);
       
        clone.GetComponent<Rigidbody2D>().velocity = transform.right * bulletvelocity;

    }
}
