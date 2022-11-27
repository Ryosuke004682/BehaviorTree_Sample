using BehaviorTree;
using UnityEngine;

public class EnemyChecker : Node
{
    private static int _enemySearchRange = 1 >> 6;
    private Transform _transform;

    public EnemyChecker(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        object target = GetData("Enemy");
        
        if(target == null)
        {
            //OverlapSphereは指定された位置の周りの球内で見つかったコライダーを全て返す。
            Collider[] collider = Physics.OverlapSphere(_transform.position, EnemysBT.forRange,
                                                                            _enemySearchRange);

            if(collider.Length > 0)
            {
                //少なくとも一つのコライダーを見つけたら、ターゲットスロットに格納する。
                parent.parent.SetData("Enemy" , collider[0].transform);
            }
            state = NodeState.FAILUED;
            return state;
        }

        state = NodeState.SUCCESS;
        return state;

    }
}
