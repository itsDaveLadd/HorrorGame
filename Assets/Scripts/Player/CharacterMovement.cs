using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Dependencies")]
    public CharacterController controller;
    public Transform groundCheck;

    [Header("Vitals")]
    public float HungerLevel;
    public float ThristLevel;
    public float StaminaLevel;
    public float MetabalismLevel;


    [Header("Characteristics")]
    public string Name;
    public float Height;
    public float Weight;
    public int Age;



    public float MovementSpeed = 12f;
    public float JumpHeight = 3f;
    public float GravityPull = -9.81f;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;


    bool isGrounded;
    Vector3 velocity;


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, GroundDistance, GroundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * MovementSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        { 
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * GravityPull);
        }

        velocity.y += GravityPull * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
