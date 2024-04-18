using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Gunshoot : MonoBehaviour
{
    public float ammo, totalammo, range, nextshoot, shootTime, Magsammo, Num, ReloadTime, MaxTime,attackDamage;
    public bool shoot, Reload;
    RaycastHit hit;
    public TextMeshProUGUI AmmoText, totalAmmoText;
    public proceduralrecoil recoil;

    public bool Zoom;
    public AudioSource audioSource;
    public AudioClip ShootingSound;
    public AudioClip ReloadSound;
    public float Damage = 10;
    public Ray ray;
    private Animator isreloading;
    bool isReloading;
    public int TakeDamage;
    private void Start()
    {
        isreloading = GetComponent<Animator>();
        ReloadTime = MaxTime;

    }

    private void Update()
    {
        AmmoText.text = "" + ammo;
        totalAmmoText.text = "" + totalammo;

        if (Input.GetMouseButton(0) && ammo > 0 && Time.time > nextshoot && !Reload)
        {
            shoot = true;

            nextshoot = Time.time + shootTime;
            ammo--;

        }


        if ((Input.GetKeyDown(KeyCode.R) || ammo == 0) && !isReloading)
        {
            // Reload = true;
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
        //         isreloading.SetTrigger("reload");


        //     }
        // }
    }

    IEnumerator ReloadGun()
    {
        isReloading = true;
        audioSource.PlayOneShot(ReloadSound);
        isreloading.SetTrigger("reload");

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
                if (hit.transform.tag == "Enemy")
                { 
                  CharacterStats EnemyStats=hit.transform.GetComponent<CharacterStats>();
                    EnemyStats.TakeDamage();
                }
                
                
                TigerHealth tigerHealth = hit.collider.GetComponent<TigerHealth>();
                if (tigerHealth != null)
                {
                    tigerHealth.TakeDamage(attackDamage);
                }
            }
        }
    }
}
