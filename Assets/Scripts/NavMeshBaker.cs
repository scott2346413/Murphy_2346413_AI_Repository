using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.ARFoundation;

public class NavMeshBaker : MonoBehaviour
{
    public Transform player;
    public ARPlaneManager _ARPlaneManager;
    public NavMeshAgent[] agents;

    private void Start()
    {
        agents = FindObjectsOfType<NavMeshAgent>();
        SetAgentsEnabled(false);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var plane in _ARPlaneManager.trackables)
        {
            if (plane.transform.position.y < player.position.y)
            {
                plane.GetComponent<NavMeshSurface>().BuildNavMesh();
                SetAgentsEnabled(true);
            }
        }
    }

    void SetAgentsEnabled(bool enabled)
    {
        foreach (NavMeshAgent agent in agents)
        {
            agent.enabled = enabled;
        }
    }
}
