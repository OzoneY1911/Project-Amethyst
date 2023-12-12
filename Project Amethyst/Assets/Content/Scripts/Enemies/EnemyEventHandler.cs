using UnityEngine;

public class EnemyEventHandler : MonoBehaviour
{
    private EnemyAI _enemyAI => GetComponent<EnemyAI>();

    private void EventRam()
    {
        _enemyAI._targetFence.gameObject.GetComponent<DestructibleFence>().Break();
    }

    private void EventAttack()
    {
        PlayerHealth.Instance.ChangeHealth(-_enemyAI.Enemy.Damage);
    }

    private void EventRamTarget()
    {
        TargetStructure.Instance.Break(_enemyAI.Enemy.Damage);
    }
}