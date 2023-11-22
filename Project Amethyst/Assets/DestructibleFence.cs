using UnityEngine;
using UnityEngine.UI;

public class DestructibleFence : MonoBehaviour
{
    private static InputManager _inputManager => InputManager.Instance;

    [SerializeField] private float _health;
    private float _maxHealth = 100;

    [SerializeField] private GameObject _repairHint;
    [SerializeField] private GameObject _healthBar;
    [SerializeField] private Slider _healthFill;

    [SerializeField] private GameObject[] _plank;

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
        else
        {
            Break();

            if (_health == 0f)
            {
                foreach (var val in _plank)
                {
                    val.SetActive(false);
                }
            }
        }
    }

    private void UpdateHealthBar()
    {
        _healthFill.value = _health / 100f;
    }

    public void Break()
    {
        _health -= 0.25f;
        UpdateHealthBar();

        if (_health == 0f && !_plank[0].activeSelf)
        {
            _plank[0].SetActive(false);
        }

        if (_health <= 33f && !_plank[1].activeSelf)
        {
            _plank[1].SetActive(false);
        }

        if (_health <= 67f && !_plank[2].activeSelf)
        {
            _plank[2].SetActive(false);
        }


        if (_health < 0f)
        {
            _health = 0f;
        }
    }

    private void Repair()
    {
        _health += 0.5f;
        UpdateHealthBar();

        if (_health > 33f && !_plank[0].activeSelf)
        {
            _plank[0].SetActive(true);
        }
        
        if (_health > 67f && !_plank[1].activeSelf)
        {
            _plank[1].SetActive(true);
        }

        if (_health == _maxHealth)
        {
            _plank[2].SetActive(true);
        }
    }
}