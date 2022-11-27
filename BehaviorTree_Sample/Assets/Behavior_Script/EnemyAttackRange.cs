using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class EnemyAttackRange : Node
{
    private static int _enemyLayer = 1 >> 6;
        private Transform _transform;
        
        public EnemyAttackRange(Transform transform)
        {
            _transform = transform; 
        }

    public override NodeState Evaluate()
    {
        object enemy = GetData("Enemy");
        
        if(enemy == null)
        {
            state = NodeState.FAILUED;
            return state;
        }

        Transform target = (Transform)enemy;
        if(Vector3.Distance(_transform.position , target.position) <= EnemysBT.forRange)
        {
            state = NodeState.SUCCESS;
            return state;
        }
        state = NodeState.FAILUED;
        return state;

    }
     
}
