using UnityEngine;
using UnityEngine.UI;

public class DestructibleFence : MonoBehaviour
{
    private static InputManager _inputManager => InputManager.Instance;

    [SerializeField] private int _health;
    private int _maxHealth = 100;

    [SerializeField] private GameObject _repairHint;
    [SerializeField] private GameObject _healthBar;
    [SerializeField] private Slider _healthFill;

    private bool _inRange;
    private bool _canRepair;

    private void Awake()
    {
        _health = _maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _inRange = true;
            UpdateHealthBar();
            _repairHint.SetActive(true);
            _healthBar.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _inRange = false;
            _repairHint.SetActive(false);
            _healthBar.SetActive(false);
        }
    }

    private void Update()
    {
        if (_inRange && _inputManager.GetPlayerInteract() && _health < _maxHealth)
        {
            if (!_canRepair)
            {
                _canRepair = !_canRepair;
            }
        }
        else if (_canRepair)
        {
            _canRepair = !_canRepair;
        }
    }

    private void FixedUpdate()
    {
        if (_canRepair)
        {
            Repair();
        }
    }

    private void UpdateHealthBar()
    {
        _healthFill.value = _health / 100f;
    }

    private void Repair()
    {
        _health++;
        UpdateHealthBar();
    }
}