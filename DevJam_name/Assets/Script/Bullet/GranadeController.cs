using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GranadeController : MonoBehaviour
{
    [Header("Granade")]
    public GameObject granade;
    public Transform pointShootGranade;

    [Header("Stats Granade")]
    public float G_damage;
    public float G_bulletvelocity;

    [Header("Ammunition Weapon")]
    public int G_Maxgranade;
    public int G_amountgranade;
    public TextMeshProUGUI G_amountTxt;

    private PlayerController player;

    private void Start()
    {
        G_amountgranade = G_Maxgranade;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        G_amountTxt.SetText(G_amountgranade + "X");
    }

    private void Update()
    {
        G_amountTxt.SetText(G_amountgranade + "X");


        if (Input.GetKeyDown(KeyCode.Mouse1) && G_amountgranade > 0)
        {
            G_amountgranade--;

            GranadeClone();
        }
    }


    public void GranadeClone()
    {
        GameObject clone = Instantiate(granade, pointShootGranade.position, Quaternion.identity);
        clone.GetComponent<Granade>().damage = G_damage;
        clone.GetComponent<Rigidbody2D>().velocity = (transform.up * 40);
        clone.GetComponent<Rigidbody2D>().velocity = (transform.right * G_bulletvelocity);

    }
}
