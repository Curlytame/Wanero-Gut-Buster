using System.Collections.Generic;

namespace EnemyAI_BT
{
    public class Sequence : Node
    {
        private List<Node> nodes;
        public Sequence(List<Node> nodes) { this.nodes = nodes; }

        public override NodeState Evaluate()
        {
            bool anyRunning = false;
            foreach (Node node in nodes)
            {
                NodeState result = node.Evaluate();
                if (result == NodeState.FAILURE) { _state = NodeState.FAILURE; return _state; }
                if (result == NodeState.RUNNING) anyRunning = true;
            }
            _state = anyRunning ? NodeState.RUNNING : NodeState.SUCCESS;
            return _state;
        }
    }
}
