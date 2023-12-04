using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentCirclePlayer : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public float circleDistance;

    public float wait;
    float switchTargetTime = 0;
    int currentTarget = 0;
    Vector3[] targetOffsets = { Vector3.forward, Vector3.right, Vector3.back, Vector3.left };

    private void Start()
    {
        player = FindObjectOfType<Camera>().transform;
    }

    private void Update()
    {
        if (Time.deltaTime > switchTargetTime)
        {
            currentTarget++;
            if(currentTarget <= targetOffsets.Length)
            {
                currentTarget = 0;
            }

            agent.SetDestination(player.transform.position + targetOffsets[currentTarget]*circleDistance);
            switchTargetTime += wait;
        }

    }
}
