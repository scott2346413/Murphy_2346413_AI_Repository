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

    public Vector3 spawnPoint;

    private void Start()
    {
        spawnPoint = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent.SetDestination(player.transform.position + Random.insideUnitSphere.normalized * distanceFromPlayer);
    }

    [YarnCommand("leave")]
    public void Leave()
    {
        agent.SetDestination(spawnPoint);
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }

}
