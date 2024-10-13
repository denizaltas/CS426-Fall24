using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBehavior : MonoBehaviour
{

    private Rigidbody rb;

    public float forceAmount = 100f;

    
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
      
        rb.AddForce(Vector3.up * forceAmount);
    }
}
