using UnityEngine;

namespace EnemyAI_BT
{
    public class EnemyUseBuffNode : Node
    {
        private EnemyManager enemy;
        public EnemyUseBuffNode(EnemyManager enemy) { this.enemy = enemy; }

        public override NodeState Evaluate()
        {
            enemy.UseBuffCard(); // Make sure EnemyManager has this function
            _state = NodeState.SUCCESS;
            return _state;
        }
    }
}
