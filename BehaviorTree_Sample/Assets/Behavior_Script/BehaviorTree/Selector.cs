using System.Collections.Generic;

namespace BehaviorTree
{
    /// <summary>
    /// ノードクラスから派生させる。
    /// </summary>
    public class Selector : Node
    {
        public Selector() : base() { }
        public Selector(List<Node> children) : base(children) { }

        public override NodeState Evaluate()
        {
            foreach (Node node in children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.FAILUED:
                        continue;


                    case NodeState.SUCCESS:
                        state = NodeState.SUCCESS;
                        return state;

                    case NodeState.RUNNING:
                        state = NodeState.RUNNING;
                        return state;

                    default:
                        continue;
                }
            }

            state = NodeState.FAILUED;
            return state;

        }
    }

}
