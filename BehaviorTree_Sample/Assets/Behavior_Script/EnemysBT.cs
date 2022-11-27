using BehaviorTree;
using System.Collections.Generic;

public class EnemysBT : Tree
{
    public UnityEngine.Transform[] waypoint;

    public static float speed = 4;
    public static float forRange = 6.0f;

    protected override Node SetUpTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new EnemyChecker(transform),
                new EnemyTask(transform)
            }),
            new TaskPatrol(transform,waypoint)
        });
        return root;
    }
}
