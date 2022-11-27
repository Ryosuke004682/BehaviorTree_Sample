using UnityEngine;
using BehaviorTree;

public class TaskAttack : Node
{
    private Transform _lastTarget;
    private EnemyManager _enemyManager;

    private float _attackTime  = 1.0f;
    private float _attackCount = 0.0f;

    public TaskAttack(Transform transform)
    {
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("Enemy");
        
        if(target != _lastTarget)
        {
            _enemyManager = target.GetComponent<EnemyManager>();
            _lastTarget = target;
        }

        _attackCount += Time.deltaTime;
        if(_attackCount >= _attackTime)
        {
            bool enemyIsDead = _enemyManager.TaskHit();
            if(enemyIsDead)
            {
                ClearData("Enemy");
            }
            else
            {
                _attackCount = 0.0f;
            }
        }
        

        state = NodeState.RUNNING;
        return state;
    }
}
