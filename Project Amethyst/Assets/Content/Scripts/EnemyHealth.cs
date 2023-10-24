public class EnemyHealth : EntityHealth
{
    protected override void Init()
    {
        _health = GetComponent<EnemyController>().Enemy.MaxHealth;
    }

    protected override void Die()
    {
        gameObject.SetActive(false);
    }
}