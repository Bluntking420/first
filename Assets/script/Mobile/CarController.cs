using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public float MaxSpeed;
    private float speedClamped;
    public int isEngineRunning;
    public float RPM;
    public float RedLight;
    public float idleRPM;
    public TMP_Text rpmText;
    public TMP_Text gearText;
    public Transform rpmNeedle;
    public int currentGear;
    public float minNeedleRotation;
    public float maxNeedleRotation;
    public float[] gearRatios;
    public float differentialRatio;
    private float currentTorque;
    private float clutch;
    private float wheelRPM;
    public AnimationCurve hpToRPMCurve;
    // Start is called before the first frame update
    void Start()
    {
      PlayerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rpmNeedle.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(minNeedleRotation, maxNeedleRotation, RPM / RedLight));
        rpmText.text = RPM.ToString("0,000") + "RPM";
        gearText.text = (currentGear + 1).ToString();
        Speed = colliders.RRWheel.rpm*colliders.RRWheel.radius*2f*Mathf.PI/10;
        speedClamped = Mathf.Lerp(speedClamped, Speed, Time.deltaTime);
        CheckInput();
        ApplyMotor();
        ApplyWheelPosition(); 
        ApplySteering();   
        ApplyBrake();
    }



    void CheckInput()
    {
        gasInput = Input.GetAxis("Vertical");
        if (Mathf.Abs(gasInput) > 0 && isEngineRunning==0)
        {
           StartCoroutine( GetComponent<EngineAudio>().StartEngine());
        }
        
        
        
        steeringInput = Input.GetAxis("Horizontal");
        slipAngle = Vector3.Angle(transform.forward,PlayerRB.velocity-transform.forward);
        clutch = (Input.GetKey(KeyCode.LeftShift) ? 0 : Mathf.Lerp(clutch, 1, Time.deltaTime));
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
        currentTorque = CalculateTorque();
                colliders.RRWheel.motorTorque=currentTorque*gasInput ;
                colliders.RLWheel.motorTorque=currentTorque*gasInput ;
            
    }
    float CalculateTorque()
    {
        float torque = 0;
        if(isEngineRunning > 0)
        {
            if (clutch < 0.1f)
            {
                RPM = Mathf.Lerp(RPM, Mathf.Max(idleRPM, RedLight * gasInput) + Random.Range(-50, 50), Time.deltaTime);
            }
            else
            {
                wheelRPM = Mathf.Abs((colliders.RRWheel.rpm + colliders.RLWheel.rpm) / 2F) * gearRatios[currentGear] * differentialRatio;
                RPM=Mathf.Lerp(RPM, Mathf.Max(idleRPM-100,wheelRPM), Time.deltaTime*3f);
                torque=(hpToRPMCurve.Evaluate(RPM/RedLight)*motorPower/RPM)*gearRatios[currentGear]*differentialRatio*5252f*clutch;
            }
        }
         return torque;
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
    public float GetSpeedRatio()
    { 
     var gas=Mathf.Clamp(Mathf.Abs(gasInput),0.5f,1f);
        return speedClamped * gas / MaxSpeed;
    
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
