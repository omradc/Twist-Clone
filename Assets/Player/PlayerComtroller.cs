using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComtroller : MonoBehaviour
{
    public float speed;
    public float jump;
    public float gravity;
    bool isJump;
    bool gameStarted;
    Rigidbody rb;
    void Start()
    {
        Physics.gravity = new Vector3(0, -gravity, 0);
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameStarted = true;
            Jump();
        }

        Forward();
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
        isJump = true;
        rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        isJump = false;
    }


}
