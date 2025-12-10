using EnemyAI_BT;

public class EnemyAttackNode : Node
{
    private EnemyManager _enemy;

    public EnemyAttackNode(EnemyManager enemy)
    {
        _enemy = enemy;
    }

    public override NodeState Evaluate()
    {
        if (_enemy.HasAttackCardInHand())
        {
            _enemy.PlayAttackCardFromHand(); // Play attack card from hand
            return NodeState.SUCCESS;
        }

        return NodeState.FAILURE;
    }
}
