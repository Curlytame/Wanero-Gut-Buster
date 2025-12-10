using EnemyAI_BT;

public class EnemyUseBuffNode : Node
{
    private EnemyManager _enemy;

    public EnemyUseBuffNode(EnemyManager enemy)
    {
        _enemy = enemy;
    }

    public override NodeState Evaluate()
    {
        if (_enemy.HasBuffCardInHand())
        {
            _enemy.UseBuffCardFromHand(); // Use the card from hand
            return NodeState.SUCCESS;
        }

        return NodeState.FAILURE;
    }
}
