using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Yarn.Unity;

public class followNearPlayer : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public Transform model;

    public Vector3 standOffset;

    public Animator animator;

    public bool follow = true;
    float originalY;

    private void Start()
    {
        originalY = model.position.y;
        follow = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled)
        {
            Vector3 position = model.localPosition;

            if (follow)
            {
                position.y = originalY;

                Vector3 newDestination = player.position + player.forward * standOffset.z + player.right * standOffset.x;

                if (Vector3.Distance(newDestination, agent.transform.position) > 2.5f)
                {
                    agent.SetDestination(newDestination);
                }
            }
            else
            {
                position.y = originalY+1.5f;
            }

            if (agent.velocity.magnitude < 0.5f)
            {
                Vector3 lookatPosition = player.position;
                lookatPosition.y = transform.position.y;
                Vector3 lookToward = Vector3.Lerp(transform.position + transform.forward, lookatPosition, Time.deltaTime * 3);
                transform.LookAt(lookToward);
            }

            if (animator != null)
            {
                animator.SetFloat("speed", agent.velocity.magnitude);
            }

            model.localPosition = Vector3.Lerp(model.localPosition, position, Time.deltaTime * 2);
        }
    }
}
