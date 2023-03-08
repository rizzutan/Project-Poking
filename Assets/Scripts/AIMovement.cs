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
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        GameObject parentWaypoint = GameObject.FindWithTag("Waypoints");
        waypoints = parentWaypoint.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float velocity = Mathf.Abs(rb.velocity.magnitude);
        animator.SetFloat("Velocity", velocity);
            if (reachedWaypoint == true)
        {
            int randomIndex = Random.Range(0, waypoints.Length);
            randomTarget = waypoints[randomIndex];
            agent.SetDestination(randomTarget.position);
            reachedWaypoint = false;
        }
        float distance = Vector3.Distance(transform.position, randomTarget.position);
        if (distance <= radiusRange)
        {
            reachedWaypoint = true;
        }
    }
}
