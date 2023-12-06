using UnityEngine;

public abstract class EntityHealth : MonoBehaviour
{
    protected int _health { get; set; }

    protected abstract void Init();
    protected abstract void Die();

    private void Awake()
    {
        Init();
    }

    public void ChangeHealth(in int value)
    {
        _health += value;

        if (CheckIfDead())
        {
            Die();
        }
    }

    protected virtual bool CheckIfDead()
    {
        if (_health <= 0)
        {
            _health = 0;
            return true;
        }

        return false;
    }
}