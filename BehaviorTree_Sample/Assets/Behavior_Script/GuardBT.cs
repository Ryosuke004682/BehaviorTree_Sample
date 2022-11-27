using BehaviorTree;
using Unity.VisualScripting;

public class GuardBT : Tree
{
    public UnityEngine.Transform[] waypoint;

    public static float speed = 2;

    protected override Node SetUpTree()
    {
        Node root = new TaskPatrol(transform , waypoint);
        return root;
    }
}
