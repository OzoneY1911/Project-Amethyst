using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : SingletonMono<PlayerHealth>
{
    protected static InputManager _inputManager => InputManager.Instance;

    [SerializeField] private Slider _healthBar;
    [SerializeField] private GameObject _deathScreen;
    [SerializeField] private GameObject _hurtScreen;

    private int _health;
    private int _maxHealth = 100;

    public int MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            UpdateHealthBar();
        }
    }

    protected override void Awake()
    {
        base.Awake();

        _health = MaxHealth;
        UpdateHealthBar();
    }

    public void ChangeHealth(in int value)
    {
        if (value < 0)
        {
            _hurtScreen.GetComponent<CanvasGroup>().alpha = 1f;
            _hurtScreen.GetComponent<FadeCanvasGroup>().HideCanvas();
        }

        _health += value;

        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }

        UpdateHealthBar();

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

    public void Die()
    {
        Leaderboard.Instance.UpdateBoard();
        DeathReport.Instance.UpdateReport();

        _inputManager.DisableInput();

        _deathScreen.GetComponent<FadeCanvasGroup>().ShowCanvas();
        Time.timeScale = 0f;
    }

    private void UpdateHealthBar()
    {
        _healthBar.value = _health / 100f;
    }
}