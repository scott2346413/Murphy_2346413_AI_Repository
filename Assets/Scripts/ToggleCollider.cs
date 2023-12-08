using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Yarn.Unity;

public class ToggleCollider : MonoBehaviour
{
    public Collider collider;
    public followNearPlayer follow;

    [YarnCommand("toggle_collider")]
    public void ColliderToggle()
    {
        collider.enabled = !collider.enabled;
        follow.follow = !follow.follow;
    }
}
