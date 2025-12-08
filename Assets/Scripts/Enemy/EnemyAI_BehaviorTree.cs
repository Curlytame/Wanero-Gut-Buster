using UnityEngine;
using System.Collections.Generic;
using EnemyAI_BT;

public class EnemyAI_BehaviorTree : MonoBehaviour
{
    [Header("Target Enemy Manager")]
    public EnemyManager enemy;   // DRAG THE ENEMY MANAGER OBJECT HERE

    private Node rootNode;

    void Start()
    {
        if (enemy == null)
        {
            Debug.LogError("❌ EnemyManager is NOT assigned in the Behavior Tree!");
            return;
        }

        BuildTree();
    }

    void BuildTree()
    {
        rootNode = new Selector(new List<Node>
        {
            // PRIORITY 1: Use buff if possible
            new Sequence(new List<Node>
            {
                new EnemyCanUseBuffNode(enemy),
                new EnemyUseBuffNode(enemy)
            }),

            // PRIORITY 2: If no buff, attack
            new EnemyAttackNode(enemy)
        });
    }

    // Call this from TurnManager during enemy turn
    public void RunTree()
    {
        if (rootNode != null)
            rootNode.Evaluate();
    }
}
