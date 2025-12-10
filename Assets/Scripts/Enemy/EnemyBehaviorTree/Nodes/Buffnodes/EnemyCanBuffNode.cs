using EnemyAI_BT;

public class EnemyCanBuffNode : Node
{
    private EnemyManager _enemy;

    public EnemyCanBuffNode(EnemyManager enemy)
    {
        _enemy = enemy;
    }

    public override NodeState Evaluate()
    {
        if (_enemy.HasBuffCardInHand()) // Updated method for cards in hand
        {
            return NodeState.SUCCESS;
        }
        return NodeState.FAILURE;
    }
}
