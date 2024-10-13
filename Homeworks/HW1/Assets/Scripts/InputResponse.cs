using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputResponse : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
       
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * 10);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * 10);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * 10);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * 10);
        }
    }
}
