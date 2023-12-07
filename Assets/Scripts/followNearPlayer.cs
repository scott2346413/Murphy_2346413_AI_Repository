using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Yarn.Unity;

public class followNearPlayer : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    public Vector3 standOffset;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled)
        {
            Vector3 newDestination = player.position + player.forward * standOffset.z + player.right * standOffset.x;

            if(Vector3.Distance(newDestination, agent.transform.position) > 2f)
            {
                agent.SetDestination(newDestination);
            }

            if(agent.velocity.magnitude < 0.5f)
            {
                Vector3 lookatPosition = player.position;
                lookatPosition.y = transform.position.y;
                Vector3 lookToward = Vector3.Lerp(transform.position + transform.forward, lookatPosition, Time.deltaTime*3);
                transform.LookAt(lookToward);
            }

            if(animator != null)
            {
                animator.SetFloat("speed", agent.velocity.magnitude);
            }
        }
    }
}
