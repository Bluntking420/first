using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpuidSwitch : MonoBehaviour
{

    public GameObject slot1;
    public GameObject slot2;   
    public GameObject slot3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            Equip1();
        }
        if (Input.GetKeyDown("2"))
        {
            Equip2();
        }
        if (Input.GetKeyDown("3"))
        {
            Equip3();
        }
    }
    void Equip1()
    { 
     slot1.SetActive(true);
        slot2.SetActive(false);
        slot3.SetActive(false);
    }

    void Equip2()
    {
        slot1.SetActive(false);
        slot2.SetActive(true);
        slot3.SetActive(false);
    }

    void Equip3()
    {
        slot1.SetActive(false);
        slot2.SetActive(false);
        slot3.SetActive(true);
    }

}

