using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Yarn.Unity;

public class PhirakianMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public float distanceFromPlayer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent.SetDestination(player.transform.position + Random.insideUnitSphere.normalized * distanceFromPlayer);

        if (agent.velocity.magnitude < 0.5f)
        {
            Vector3 lookatPosition = player.position;
            lookatPosition.y = transform.position.y;
            Vector3 lookToward = Vector3.Lerp(transform.position + transform.forward, lookatPosition, Time.deltaTime * 3);
            transform.LookAt(lookToward);
        }
    }

    IEnumerator StopWalking()
    {
        yield return new WaitForSeconds(3);

        agent.SetDestination(transform.position);
    }

}
