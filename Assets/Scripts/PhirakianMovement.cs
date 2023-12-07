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
    }

}
