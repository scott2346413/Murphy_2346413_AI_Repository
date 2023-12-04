using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Yarn.Unity;

public class followNearPlayer : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    bool followInfront = false;

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled)
        {
            if (followInfront)
            {
                agent.SetDestination(player.position + player.forward * 1f + player.right * 0.5f);
                Vector3 lookAtPosition = player.position;
                lookAtPosition.y = agent.transform.position.y;
                agent.transform.LookAt(lookAtPosition);
            }
            else
            {
                agent.SetDestination(player.position + Vector3.forward * 1f + Vector3.right * 0.5f);
                Vector3 lookAtPosition = player.position;
                lookAtPosition.y = agent.transform.position.y;
                agent.transform.LookAt(lookAtPosition);
            }
        }
        
    }

    [YarnCommand("follow_infront")]
    public void enableFollowInfront()
    {
        followInfront = true;
    }

    [YarnCommand("stop_follow_infront")]
    public void disableFollowInfront()
    {
        followInfront = false;
    }
}
