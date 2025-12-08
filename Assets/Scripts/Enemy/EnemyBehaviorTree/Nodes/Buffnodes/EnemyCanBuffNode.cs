using EnemyAI_BT;

public class EnemyCanUseBuffNode : Node
{
    private EnemyManager enemy;
    public EnemyCanUseBuffNode(EnemyManager enemy) { this.enemy = enemy; }

    public override NodeState Evaluate()
    {
        _state = enemy.HasBuffCard() ? NodeState.SUCCESS : NodeState.FAILURE;
        return _state;
    }
}
