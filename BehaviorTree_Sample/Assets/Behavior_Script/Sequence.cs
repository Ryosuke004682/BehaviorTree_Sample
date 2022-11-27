using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    

namespace BehaviorTree
{
    /// <summary>
    /// ノードクラスから派生させる。
    /// </summary>
    public class Sequence : Node
    {
        public override NodeState Evaluate()
        {
            bool anyChildIsRunning = false;

            foreach(Node node in children)
            {
                switch(node.Evaluate())
                {
                    case NodeState.FAILUED:
                        state = NodeState.FAILUED;
                        return state;


                    case NodeState.SUCCESS:
                        continue;

                    case NodeState.RUNNING:
                        anyChildIsRunning = true;
                        continue;

                    default:
                        state = NodeState.SUCCESS;
                        return state;
                }
            }

            state = anyChildIsRunning ? NodeState.RUNNING : NodeState.SUC;
            return state;

        }
    }

}
