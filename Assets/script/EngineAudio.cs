using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EngineAudio : MonoBehaviour
{
    public AudioSource RunningSound;
    public float runningMaxVolume;
    public float runningMaxPitch;
    public AudioSource ReverseSound;
    public float reverseMaxVolume;
    public float reverseMaxPitch;
    public AudioSource IdleSound;
    public float IdleMaxVolume;
    public float LimiterSound = 1f;
    public float LimiterFrequency = 3f;
    public float LimiterEngage = 0.8f;
    private float revLimiter;
    private CarController carController;
    private float speedRatio;
    public AudioSource startingSound;
    public bool isEngineRunning=false;
   
    

    // Start is called before the first frame update
    void Start()
    {
        carController = GetComponent<CarController>();
        IdleSound.volume = 0;
        RunningSound.volume = 0;
        ReverseSound.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
       

        float speedSign=0;
        if (carController)
        {
            speedSign = Mathf.Sign(carController.GetSpeedRatio());
            speedRatio = Mathf.Abs(carController.GetSpeedRatio());

        }
       
        if (speedRatio > LimiterEngage)
        {
            revLimiter = (Mathf.Sin(Time.time * LimiterFrequency) + 1f)*LimiterSound * (speedRatio - LimiterEngage);

        }
         


        if (isEngineRunning)
        {

            IdleSound.volume = Mathf.Lerp(0.1f, IdleMaxVolume, speedRatio);
            if (speedSign > 0)
            {
                ReverseSound.volume = 0;
                RunningSound.volume = Mathf.Lerp(0.3f, runningMaxVolume, speedRatio);
                RunningSound.pitch = Mathf.Lerp(RunningSound.pitch, Mathf.Lerp(0.3f, reverseMaxPitch, speedRatio) + revLimiter, Time.deltaTime) + revLimiter;
            }
            else {
                RunningSound.volume = 0;
                ReverseSound.volume = Mathf.Lerp(0f, reverseMaxVolume, speedRatio);
                ReverseSound.pitch = Mathf.Lerp(ReverseSound.pitch, Mathf.Lerp(0.2f, reverseMaxPitch, speedRatio) + revLimiter, Time.deltaTime) + revLimiter;
            }
            }
        else
        {
            IdleSound.volume = 0;
            RunningSound.volume = 0;
        
        }

    }
    public IEnumerator StartEngine()
    { 
      startingSound.Play();
        carController.isEngineRunning = 1;
        yield return new WaitForSeconds(0.6f);
        isEngineRunning = true;
        yield return new WaitForSeconds(0.4f);
        carController.isEngineRunning = 2;
    }

}



