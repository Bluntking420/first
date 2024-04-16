using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    public Transform target; // Target to follow and attack (usually the player)
    public float detectionRange = 10f; // Range within which the enemy detects the target
    public float attackRange = 2f; // Range within which the enemy attacks the target
    public float rotationSpeed = 5f; // Speed at which the enemy rotates towards the target

    private NavMeshAgent navMeshAgent; // Reference to the NavMeshAgent component
    private Animator animator; // Reference to the Animator component
    private bool isPlayerInRange; // Flag indicating if the player is in attack range

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (target == null)
        {
            Debug.LogError("Player GameObject not found! Make sure the player has the 'Player' tag.");
        }
    }

    void Update()
    {
        // Check if target is within detection range
        if (Vector3.Distance(transform.position, target.position) <= detectionRange)
        {
            isPlayerInRange = true;

            // Move towards the target
            navMeshAgent.SetDestination(target.position);
            animator.SetBool("isRunning", true);

            // Check if target is within attack range
            if (Vector3.Distance(transform.position, target.position) <= attackRange)
            {
                Attack();
            }
        }
        else
        {
            isPlayerInRange = false;
            animator.SetBool("isRunning", false);
        }

        // Rotate towards the target
        if (isPlayerInRange)
        {
            RotateTowardsTarget();
        }
    }

    void RotateTowardsTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    void Attack()
    {
        // Implement attack logic here
        animator.SetTrigger("attack");
       
    }
}
