using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class RunToRandomPosition : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;

    private Vector3 targetPosition;

    public float _waitTime;
    private float _waitTimer;
    public float wanderDistance;

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled == false)
            return;

        if (_waitTimer < _waitTime)
        {
            _waitTimer += Time.deltaTime;
        }
        else
        {
            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * wanderDistance;

            randomDirection += transform.position;

            NavMeshHit navHit;

            NavMesh.SamplePosition(randomDirection, out navHit, wanderDistance, NavMesh.AllAreas);

            targetPosition = navHit.position;

            agent.SetDestination(targetPosition);

            _waitTimer = 0f;
        }

        animator.SetFloat("speed", agent.speed);
    }
}
