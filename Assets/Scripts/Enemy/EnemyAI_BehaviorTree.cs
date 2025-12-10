using System.Collections.Generic;
using UnityEngine;
using EnemyAI_BT;

public class EnemyAI_BehaviorTree : MonoBehaviour
{
    private Node _root;
    private EnemyManager _enemy;

    private void Awake()
    {
        _enemy = GetComponent<EnemyManager>();

        if (_enemy == null)
        {
            Debug.LogError("❌ EnemyManager not found on this GameObject");
            return;
        }

        BuildTree();
    }

    private void BuildTree()
    {
        // Sequence: If has buff → use buff
        Sequence tryBuff = new Sequence(new List<Node>
        {
            new EnemyCanBuffNode(_enemy),  // <-- match your actual node class name
            new EnemyUseBuffNode(_enemy)
        });

        // Selector: Try buff first → else attack
        _root = new Selector(new List<Node>
        {
            tryBuff,
            new EnemyAttackNode(_enemy)
        });

        Debug.Log("✅ Enemy Behavior Tree Built");
    }

    public void RunTree()
    {
        if (_root == null)
        {
            Debug.LogError("❌ Behavior Tree not built!");
            return;
        }

        _root.Evaluate();
    }
}
