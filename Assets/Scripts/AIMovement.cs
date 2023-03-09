using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    private Rigidbody rb;
    private Animator animator;
    private Transform[] waypoints;
    private bool reachedWaypoint = true;
    private Transform randomTarget;
    public float radiusRange = 2f;
    private float timerDuration = 3f;
    private float elapsedTime = 100f;
    private Vector3 previousPosition;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        GameObject parentWaypoint = GameObject.FindWithTag("Waypoints");
        waypoints = parentWaypoint.GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        Vector3 displacement = transform.position - previousPosition;
        float displacementMag = Vector3.Distance(transform.position, previousPosition) * 100;
        previousPosition = transform.position;
        animator.SetFloat("Velocity", displacementMag);

        if (reachedWaypoint == true && elapsedTime >= timerDuration)
        {
            int randomIndex = Random.Range(0, waypoints.Length);
            randomTarget = waypoints[randomIndex];
            agent.SetDestination(randomTarget.position);
            reachedWaypoint = false;
        }

        float distance = Vector3.Distance(transform.position, randomTarget.position);
        if (distance <= radiusRange && reachedWaypoint == false)
        {
            reachedWaypoint = true;
            elapsedTime = 0f;
            timerDuration = Random.Range(2, 10);
        }

        elapsedTime += Time.deltaTime;
    }
}
