using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PLAYERMOVEMENT : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public Transform groundcheck;
    public float JumpHeight = 40f;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;
    public float originalHeight,crouchHeight;
    public float zRot;
    public Transform Bend;
    public bool isRotate;
    private float PlayerHealth=140f;
    private AudioSource audioSource;
    public AudioClip ShootingSound;
    public AudioClip ReloadSound;  
    
    

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
           
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right*x + transform.forward * z;
        controller.Move(move*speed*Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
        }

        velocity.y+=gravity*Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            controller.height=crouchHeight;
        }
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
           controller.height= originalHeight;
        }
        Bend.localRotation=Quaternion.Euler(0,0,zRot);
        if(Input.GetKey(KeyCode.Q))
        {
          zRot=Mathf.Lerp(zRot,12.0f,5f*Time.deltaTime);
          isRotate=true;
        }
         if(Input.GetKey(KeyCode.E))
        {
             zRot=Mathf.Lerp(zRot,-12.0f,5f*Time.deltaTime);
          isRotate=true;
        }
         if(Input.GetKeyUp(KeyCode.Q))
        {
            isRotate=false;
        }
         if(Input.GetKeyUp(KeyCode.E))
        {
            isRotate=false;
        }
        if(!isRotate)
        {
            zRot=Mathf.Lerp(zRot,0.0f,5f*Time.deltaTime);
        }
    }
}
