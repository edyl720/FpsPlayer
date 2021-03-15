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
        Vector3 velocity;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltatime);

        if (isGrounded && velocity.y < 0) 
        {
            velocity.y = -2.0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
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