using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform W_Check;
    public float W_distance;
    public LayerMask whatisground;
    public bool IsWall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IsWall = Physics2D.Raycast(W_Check.position,transform.right,W_distance,whatisground);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
       
    }
}
