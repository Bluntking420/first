using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowPlayer : MonoBehaviour
{
    public Transform player;            // Reference to the player
    public float followDistance = 10f;  // Distance at which the enemy starts following

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (player == null)
            return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the player is within follow distance
        if (distanceToPlayer <= followDistance)
        {
            // Set the destination of the NavMeshAgent to the player's position
            agent.SetDestination(player.position);
        }
        else
        {
            // Stop the enemy if the player is too far
            agent.isStopped = true;
        }
    }
}


