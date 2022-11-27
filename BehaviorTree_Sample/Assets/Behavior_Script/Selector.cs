using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                        return state;


                    case NodeState.SUCCESS:
                        state = NodeState.SUCCESS;
                        continue;

                    case NodeState.RUNNING:
                        state = NodeState.RUNNING;
                        continue;

                    default:
                        state = NodeState.SUCCESS;
                        return state;
                }
            }

            state = NodeState.FAILUED;
            return state;

        }
    }

}
