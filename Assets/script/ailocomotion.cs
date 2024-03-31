using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ailocomotion : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform playerTransform;
    public Animator anim;
    public float maxTime = 1.0f;
        public float maxDistance = 1.0f;
    float Timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer-=Time.deltaTime;
        if (Timer < 0.0f)
        {
            float sqdistance = (playerTransform.position - agent.destination).sqrMagnitude;
            if (sqdistance > maxDistance*maxDistance)
            {
                agent.destination = playerTransform.position;
            }
            Timer = maxTime  ;
        }
       
        anim.SetFloat("Speed", agent.velocity.magnitude);
    }
}
