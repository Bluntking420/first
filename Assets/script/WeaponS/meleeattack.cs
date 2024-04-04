using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeattack : MonoBehaviour
{
    Animator anim;
    public AudioClip swing;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("attacking", true);
            audioSource.PlayOneShot(swing);

        }
        else if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("attacking", false);
           
        }
        
    }
}
