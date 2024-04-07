using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class snipeshoot : MonoBehaviour
{
    public float ammo, totalammo, range, nextshoot, shootTime, Magsammo, Num, ReloadTime, MaxTime;
    public bool shoot, Reload;
    RaycastHit hit;
    public TextMeshProUGUI AmmoText, totalAmmoText;
    public proceduralrecoil recoil;

    public bool isZooming;
    public AudioSource audioSource;
    public AudioClip ShootingSound;
    public AudioClip ReloadSound;
    public Animator anim;

    bool isReloading;

    private void Start()
    {
        ReloadTime = MaxTime;
        Animator anim = GetComponent<Animator>();

    }

    private void Update()
    {
        AmmoText.text = "" + ammo;
        totalAmmoText.text = "" + totalammo;

        if (Input.GetMouseButton(0) && ammo > 0 && Time.time > nextshoot && !isReloading)
        {
            shoot = true;

            nextshoot = Time.time + shootTime;
            ammo--;

        }
        if (Input.GetMouseButton(1))
        {
            isZooming = true;
            anim.SetBool("Zoom", true);
        }
        else
        {
            isZooming = false;
            anim.SetBool("Zoom",false);
        }

        if ((Input.GetKeyDown(KeyCode.R) || ammo == 0) && !isReloading && !isZooming)
        {
            Reload = true;
            StartCoroutine(ReloadGun());

        }
        // if (Reload)
        // {
        //     Num = Magsammo - ammo;
        //     ReloadTime -= Time.deltaTime;

        //     if (ReloadTime < 0)
        //     {
        //         Reload = false;
        //         ReloadTime = MaxTime;
        //         if (Num > totalammo)
        //         {
        //             ammo += totalammo;
        //             totalammo = 0;
        //         }
        //         if (Num < totalammo)
        //         {
        //             ammo += Num;
        //             totalammo -= Num;
        //         }
        //         audioSource.PlayOneShot(ReloadSound);

        //     }
        // }
    }

    IEnumerator ReloadGun()
    {
        isReloading = true;
        audioSource.PlayOneShot(ReloadSound);
        anim.SetTrigger("reload");

        yield return new WaitForSeconds(1f);
        if (Num > totalammo)
        {
            ammo += totalammo;
            totalammo = 0;
        }
        if (Num < totalammo)
        {
            ammo += Num;
            totalammo -= Num;
        }
        isReloading = false;
    }
    private void FixedUpdate()
    {
        if (shoot)
        {

            shoot = false;
            recoil.recoil();
            audioSource.PlayOneShot(ShootingSound);

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
            {
                if (hit.transform.tag == "TARGET")
                {
                    Debug.Log("SHOOT");
                }

            }
        }
    }
}
