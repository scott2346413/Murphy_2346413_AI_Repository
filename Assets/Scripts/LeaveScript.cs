using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Yarn.Unity;

public class LeaveScript : MonoBehaviour
{
    public NavMeshAgent agent;
    Vector3 spawnpoint;

    private void Start()
    {
        spawnpoint = transform.position;    
    }

    [YarnCommand("leave")]
    public void Leave()
    {
        agent.SetDestination(spawnpoint);
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
