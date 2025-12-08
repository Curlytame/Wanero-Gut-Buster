namespace EnemyAI_BT
{
    public enum NodeState { RUNNING, SUCCESS, FAILURE }

    public abstract class Node
    {
        protected NodeState _state;
        public NodeState state => _state;
        public abstract NodeState Evaluate();
    }
}
