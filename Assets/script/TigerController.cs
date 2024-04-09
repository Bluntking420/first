using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerController : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5f;
    public float stoppingDistance = 1f;
    public float attackRange = 2f;
    public AudioClip attackSound;
    public AudioClip roarSound;

    private int currentWaypointIndex = 0;
    private Animator animator;
    private AudioSource audioSource;

    private enum State
    {
        Idle,
        Running,
        Attacking
    }

    private State currentState = State.Idle;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        SetState(State.Running);
    }

    private void Update()
    {
        switch (currentState)
        {
            case State.Idle:
                // Idle logic goes here
                break;
            case State.Running:
                MoveToWaypoint();
                break;
            case State.Attacking:
                Attack();
                break;
        }
    }

    private void MoveToWaypoint()
    {
        if (waypoints.Length == 0)
            return;

        Vector3 targetPosition = waypoints[currentWaypointIndex].position;
        float distance = Vector3.Distance(transform.position, targetPosition);

        if (distance <= stoppingDistance)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            targetPosition = waypoints[currentWaypointIndex].position;
        }

        transform.LookAt(targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check for attacking condition
        if (distance <= attackRange)
        {
            SetState(State.Attacking);
        }
    }

    private void Attack()
    {
        // Play attack animation
        animator.SetTrigger("Attack");

        // Play attack sound
        if (attackSound != null)
        {
            audioSource.PlayOneShot(attackSound);
        }

        // Reset to running state after attack animation finishes
        Invoke("SetRunningState", 1.5f);
    }

    private void SetRunningState()
    {
        SetState(State.Running);
    }

    private void SetState(State newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case State.Idle:
                animator.SetBool("isRunning", false);
                break;
            case State.Running:
                animator.SetBool("isRunning", true);
                animator.SetBool("isAttacking", false);
                break;
            case State.Attacking:
                animator.SetBool("isRunning", false);
                animator.SetBool("isAttacking", true);
                break;
        }
    }

    public void PlayRoarSound()
    {
        // Play roar sound
        if (roarSound != null)
        {
            audioSource.PlayOneShot(roarSound);
        }
    }
}