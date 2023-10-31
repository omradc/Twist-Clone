using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComtroller : MonoBehaviour
{
    public float speed;
    public float jump;
    public float gravity;
    public bool isJump;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Forward();
        Jump();
    }

    void Forward()
    {
        if (!isJump)
        {
            rb.AddForce(Vector3.forward * speed, ForceMode.Force);
        }
    }

    void Jump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isJump = true;
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        isJump = false;
    }


}
