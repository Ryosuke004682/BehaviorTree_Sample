using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Bh : Node
{
    Node tree_Enum;

    public GameObject target;
    public float _trackingSpeed;

    private void OnTracking(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            transform.LookAt(target.transform);
            transform.position += transform.forward * _trackingSpeed;
        }
    }
}
