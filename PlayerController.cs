using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public CharacterController controller;
    public float gravity = -10.0f;
    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundMask;
    bool isGrounded;

    void Update()
    {   
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 velocity;

        Vector3 move = transform.right * x + transform.forward * z;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        velocity.y += gravity * Time.deltaTime;

        if (isGrounded && velocity.y < 0) 
        {
            velocity.y = -2.0f;
        }

        controller.Move(move * speed * Time.deltaTime);

        controller.Move(velocity * Time.deltaTime);
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 10.0f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 5.0f;
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            speed = 2.0f;
        }

        if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            speed = 5.0f;
        }
    }
}