using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

namespace BehaviorTree
{
    /// <summary>
    /// 実行中
    /// 成功
    /// 失敗
    /// </summary>
    public enum NodeState
    {
        RUNNING, 
        SUCCESS,
        FAILUED
        
    }

    public class Node
    {
        protected NodeState state;
        public Node parent;
        protected List<Node> children = new List<Node>();


        private Dictionary<string, object> _dataContext = new Dictionary<string, object>();

        public Node()
        {
            parent = null;
        }
        public Node(List<Node> children)
        {
            foreach (Node child in children)
            {
                _Attach(child);
            }
        }

        private void _Attach(Node node)
        {
            node.parent = this;
            children.Add(node);
        }

        //各派生ノードが独自の評価を得るために評価関数の実装
        //ノードクラスを完成させることができるように仮想化する必要がある。
        public virtual NodeState Evaluate() => NodeState.FAILUED;

        public void SetData(string key , object value)
        {
            _dataContext[key] = value;
        }

        public object GetData(string key)
        {
            object value = null;
            
            if(_dataContext.TryGetValue(key,out value))
            {
                return value;
            }

            Node node = parent;

            while(node != null)
            {
                value = node.GetData(key);
                
                if(value != null)
                {
                    return value;
                }

                node = node.parent;
            }

            return null;
        }

        public bool ClearData(string key)
        {
            if(_dataContext.ContainsKey(key))
            {
                _dataContext.Remove(key);
                return true;
            }

            Node node = parent;

            while(node != null)
            {
                bool cleared = node.ClearData(key);
                
                if (cleared)
                {
                    return true;
                }
                node = node.parent;
            }
            return false;
        }


    }

}
