using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : SingletonMono<PlayerHealth>
{
    protected static InputManager _inputManager => InputManager.Instance;
    protected static CameraController _cameraController => CameraController.Instance;

    [SerializeField] private Slider _healthBar;
    [SerializeField] private GameObject _deathScreen;

    private int _health;
    public int MaxHealth;

    protected override void Awake()
    {
        base.Awake();

        _health = MaxHealth;
        UpdateHealthBar();
    }

    public void ChangeHealth(in int value)
    {
        _health += value;
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

    private void Die()
    {
        _inputManager._playerControls.Player.Disable();
        _inputManager._playerControls.UI.Enable();
        _cameraController.DisableRotation();

        _deathScreen.GetComponent<FadeCanvasGroup>().ShowCanvas();
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }

    private void UpdateHealthBar()
    {
        _healthBar.value = _health / 100f;
    }
}