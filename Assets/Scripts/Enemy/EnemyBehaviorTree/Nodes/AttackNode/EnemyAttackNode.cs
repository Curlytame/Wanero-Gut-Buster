using UnityEngine;
using EnemyAI_BT;

public class EnemyAttackNode : Node
{
    private EnemyManager enemy;
    public EnemyAttackNode(EnemyManager enemy) { this.enemy = enemy; }

    public override NodeState Evaluate()
    {
        enemy.PlayAttackCard();
        _state = NodeState.SUCCESS;
        return _state;
    }
}
