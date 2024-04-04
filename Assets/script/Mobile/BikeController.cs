using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : MonoBehaviour
{

     float moveInput,steerInput;
    public float acceleration, maxSpeed,steerStrength;
    public Rigidbody sphererb, Bikebody;
    // Start is called before the first frame update
    void Start()
    {
        sphererb.transform.parent = null;
        moveInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");

    }

    // Update is called once per frame
    void Update()
    {
        transform.position=sphererb.position;
        Bikebody.MoveRotation(transform.rotation);
    }
    private void FixedUpdate()
    {
        Movement();
        Rotation();
    }
    void Movement()
    {
        sphererb.velocity = Vector3.Lerp(sphererb.velocity, maxSpeed * moveInput * transform.forward, Time.fixedDeltaTime*acceleration);
     
    }
    void Rotation()
    {
        transform.Rotate(0, steerInput * moveInput * steerStrength * Time.fixedDeltaTime, 0, Space.World); 
    }


}


