using UnityEngine;
using UnityEngine.UI;

public class TargetStructure : SingletonMono<TargetStructure>
{
    [SerializeField] private Slider _healthBar;

    private float _health;
    private float _maxHealth = 1000;

    protected override void Awake()
    {
        base.Awake();

        _health = _maxHealth;
        UpdateHealthBar();
    }

    public void Break(int damage)
    {
        _health -= damage;
        UpdateHealthBar();

        if (_health <= 0)
        {
            PlayerHealth.Instance.Die();
        }
    }

    private void UpdateHealthBar()
    {
        _healthBar.value = _health / _maxHealth;
    }
}