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
            //OverlapSphere�͎w�肳�ꂽ�ʒu�̎���̋����Ō��������R���C�_�[��S�ĕԂ��B
            Collider[] collider = Physics.OverlapSphere(_transform.position, EnemysBT.forRange,
                                                                            _enemySearchRange);

            if(collider.Length > 0)
            {
                //���Ȃ��Ƃ���̃R���C�_�[����������A�^�[�Q�b�g�X���b�g�Ɋi�[����B
                parent.parent.SetData("Enemy" , collider[0].transform);
            }
            state = NodeState.FAILUED;
            return state;
        }

        state = NodeState.SUCCESS;
        return state;

    }
}
