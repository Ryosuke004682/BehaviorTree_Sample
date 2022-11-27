using BehaviorTree;
using UnityEngine;

public class EnemyTask : Node
{
    private Transform _transform;

    public EnemyTask(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("Enemy");
        
        if(Vector3.Distance(_transform.position , target.position) > 0.01f)
        {
            _transform.position = Vector3.MoveTowards(_transform.position ,
                                target.position , EnemysBT.speed * Time.deltaTime);

            _transform.LookAt(target.position);
        }

        state = NodeState.RUNNING;
        return state;

    }
}
