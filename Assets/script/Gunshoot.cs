using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Gunshoot : MonoBehaviour
{
   public float ammo,totalammo, range, nextshoot,shootTime,Magsammo,Num, ReloadTime,MaxTime;
   public bool shoot,Reload;
   RaycastHit hit;
   public TextMeshProUGUI AmmoText,totalAmmoText;
    public proceduralrecoil recoil;
  
    public bool Zoom;
    public AudioSource audioSource;
    public AudioClip ShootingSound;
    public AudioClip ReloadSound;
    
    



    private void Start()
    {
        ReloadTime=MaxTime;
      
    }

    private void  Update()
    {
        AmmoText.text=""+ammo;
        totalAmmoText.text=""+totalammo;
      
        if(Input.GetMouseButton(0)&&ammo>0 && Time.time>nextshoot&&!Reload)
        {
            shoot = true;

           

        }
        




        if(Input.GetKeyDown(KeyCode.R)||ammo==0)
        {
            Reload=true;
          

        }
        if(Reload){
            Num=Magsammo-ammo;
            ReloadTime-=Time.deltaTime;
          
            if (ReloadTime<0)
            {
                Reload=false;
                ReloadTime=MaxTime;
                if(Num>totalammo)
                {
                    ammo+=totalammo;
                    totalammo=0;
                }
                if(Num<totalammo)
                {
                    ammo+=Num;
                    totalammo-=Num;
                }
                audioSource.PlayOneShot(ReloadSound);

            }
        }
    }
    private void FixedUpdate()
    {
        if(shoot){
           
            shoot=false;
            recoil.recoil();
            audioSource.PlayOneShot(ShootingSound);

            if (Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit ,range))
            {
                if(hit.transform.tag=="TARGET")
                {
                    Debug.Log("SHOOT");
                }
               
            }
        }
    }
}
