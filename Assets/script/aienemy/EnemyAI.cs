using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowPlayer : CharacterStats
{
   private NavMeshAgent agent=null;
 [SerializeField]    private Transform PlayerBody;
    private Animator anim=null;
    private EnemyStats stats=null;
    private float timeofLastAttack=0;
    private bool hasStopped=false;


    private void Start()
    {
        GetReferences();
    }

    private void Update()
    {
        MoveToTarget();
    }



    private void MoveToTarget()
    {
        agent.SetDestination(PlayerBody.position);
        anim.SetFloat("Speed", 1f, 0.3f,Time.deltaTime);
        RotateToPlayerBody();
        float distanceToPlayerBody = Vector3.Distance(PlayerBody.position, transform.position);
            if(distanceToPlayerBody <= agent.stoppingDistance)
             {
            anim.SetFloat("Speed", 0);
            //Attack
            if (!hasStopped)
            {
                hasStopped = true;
                timeofLastAttack = Time.time;
            }
            
           
            if (Time.time >= timeofLastAttack + stats.AttackSpeed)
            { 
              timeofLastAttack=Time.time;
                CharacterStats PlayerBodyStats = PlayerBody.GetComponent<CharacterStats>();
                AttackPlayerBody(PlayerBodyStats);
            }
          
              }
        
        
        
        
        if (agent.isStopped)
        {
            anim.SetFloat("Speed", 0f, 0.3f, Time.deltaTime);
        }
    }
    private void AttackPlayerBody(CharacterStats statsToDamage)
    {
        anim.SetTrigger("Attack");
        stats.DealDamage(statsToDamage);
    }



    private void RotateToPlayerBody()
    {
     transform.LookAt(PlayerBody.position);
        Vector3 direction = PlayerBody.position - transform.position;
        Quaternion quaternion = Quaternion.LookRotation(direction,Vector3.up);
        transform.rotation = quaternion;
    }
    
    
    
    private void GetReferences()
    { 
      agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        stats = GetComponent<EnemyStats>();
    }

}


