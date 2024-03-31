using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Rigidbody PlayerRB;
    public WheelColliders colliders;
    public WheelMeshes wheelMeshes;
    public float gasInput;
    public float steeringInput;
    public float motorPower;
    public float brakePower;
    public float brakeInput;
    public float slipAngle;
    public float Speed;
    public AnimationCurve steeringCurve;
    // Start is called before the first frame update
    void Start()
    {
      PlayerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Speed= PlayerRB.velocity.magnitude;
        CheckInput();
        ApplyMotor();
        ApplyWheelPosition(); 
        ApplySteering();   
        ApplyBrake();
    }

    void CheckInput()
    {
        gasInput = Input.GetAxis("Vertical");
        steeringInput = Input.GetAxis("Horizontal");
        slipAngle = Vector3.Angle(transform.forward,PlayerRB.velocity-transform.forward);
        if (slipAngle < 120)
        {
            if (gasInput < 0)
            {
                brakeInput = Mathf.Abs(gasInput);
                gasInput = 0;
            }

        }
        else
        {
            brakeInput = 0;
        }
    }

    void ApplyBrake()
    {
        colliders.FRWheel.brakeTorque = brakeInput * brakePower*0.7f;
        colliders.FLWheel.brakeTorque = brakeInput * brakePower*0.7f;
        colliders.RRWheel.brakeTorque = brakeInput * brakePower*0.3f;
        colliders.RLWheel.brakeTorque = brakeInput * brakePower*0.3f;

    }
    
    
    
    
    
    void ApplySteering()
    {
        float steeringAngle = steeringInput*steeringCurve.Evaluate(Speed);
       
      
        colliders.FRWheel.steerAngle = steeringAngle;
        colliders.FLWheel.steerAngle = steeringAngle;

      
    }
    
    
    void ApplyMotor()
    {
        colliders.RRWheel.motorTorque = motorPower * gasInput;
        colliders.RLWheel.motorTorque = motorPower * gasInput;
       
    }


    void ApplyWheelPosition()
    {
        UpdateWheel(colliders.FRWheel, wheelMeshes.FRWheel);
        UpdateWheel(colliders.FLWheel, wheelMeshes.FLWheel);
        UpdateWheel(colliders.RRWheel, wheelMeshes.RRWheel);
        UpdateWheel(colliders.RLWheel, wheelMeshes.RLWheel);

    }
    void UpdateWheel(WheelCollider coll, MeshRenderer wheelMesh)
    {
        Quaternion quat;
        Vector3 position;
        coll.GetWorldPose(out position, out quat);
        wheelMesh.transform.position = position;
        wheelMesh.transform.rotation = quat;
    }


   [System.Serializable]
    public class WheelColliders
    {
        public WheelCollider FRWheel;
        public WheelCollider FLWheel;
        public WheelCollider RRWheel;
        public WheelCollider RLWheel;
    }
    [System.Serializable]
    public class WheelMeshes
    {
        public MeshRenderer FRWheel;
        public MeshRenderer FLWheel;
        public MeshRenderer RRWheel;
        public MeshRenderer RLWheel;
    }



}
