using System.Collections.Generic;

namespace EnemyAI_BT
{
    public class Selector : Node
    {
        private List<Node> nodes;
        public Selector(List<Node> nodes) { this.nodes = nodes; }

        public override NodeState Evaluate()
        {
            foreach (Node node in nodes)
            {
                NodeState result = node.Evaluate();
                if (result == NodeState.SUCCESS) { _state = NodeState.SUCCESS; return _state; }
                if (result == NodeState.RUNNING) { _state = NodeState.RUNNING; return _state; }
            }
            _state = NodeState.FAILURE;
            return _state;
        }
    }
}
