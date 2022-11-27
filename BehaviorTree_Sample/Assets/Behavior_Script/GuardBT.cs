using BehaviorTree;
using Unity.VisualScripting;

public class EnemysBT : Tree
{
    public UnityEngine.Transform[] waypoint;

    public static float speed = 4;
    public static float forRange = 6.0f;

    protected override Node SetUpTree()
    {
        Node root = new TaskPatrol(transform , waypoint);
        return root;
    }
}
