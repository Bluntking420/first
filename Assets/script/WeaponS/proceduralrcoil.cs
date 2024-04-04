using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proceduralrecoil : MonoBehaviour
{
    Vector3 currentRotation, targetRotation, targetPosition, currentPosition, initialGunPosition;
    public Transform Camera;
   public float recoilX;
   public float recoilY;
   public float recoilZ;
   public float kickbackZ;
   public float snapiness, returnAmount;
    

    // Start is called before the first frame update
    void Start()
    {
        initialGunPosition= transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        targetRotation=Vector3.Lerp(targetRotation, Vector3.zero,Time.deltaTime*returnAmount);
        currentRotation=Vector3.Slerp(currentRotation,targetRotation,Time.fixedDeltaTime*snapiness);
        back();
 }



    public void recoil()
    {
        targetPosition -= new Vector3(0, 0, kickbackZ);
        targetRotation += new Vector3(recoilX, Random.Range(-recoilY, recoilY), Random.Range(-recoilZ, recoilZ));
    }
    void back()
    {
        targetPosition = Vector3.Lerp(targetPosition, initialGunPosition, Time.deltaTime * returnAmount);
        currentPosition=Vector3.Lerp(currentPosition,targetPosition, Time.fixedDeltaTime* snapiness);
        transform.localPosition = currentPosition;
    }
}
