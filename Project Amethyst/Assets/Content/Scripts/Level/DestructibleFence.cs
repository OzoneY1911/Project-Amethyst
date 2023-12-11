using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class DestructibleFence : MonoBehaviour
{
    private static InputManager _inputManager => InputManager.Instance;

    [SerializeField] private float _health;

    public float Health { get { return _health; } }

    private float _maxHealth = 100;

    [SerializeField] private CanvasGroup _interactHint;
    [SerializeField] private CanvasGroup _healthBar;
    [SerializeField] private Slider _healthFill;

    [SerializeField] private GameObject[] _plank;

    public NavMeshObstacle Obstacle;

    private bool _inRange;
    private bool _canRepair;

    private void Awake()
    {
        _health = _maxHealth;

        Obstacle = GetComponent<NavMeshObstacle>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _inRange = true;
            UpdateHealthBar();
            _interactHint.GetComponent<FadeCanvasGroup>().ShowCanvas();
            _healthBar.GetComponent<FadeCanvasGroup>().ShowCanvas();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _inRange = false;
            _interactHint.GetComponent<FadeCanvasGroup>().HideCanvas();
            _healthBar.GetComponent<FadeCanvasGroup>().HideCanvas();
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

    public void Break()
    {
        _health -= 25f;

        if (_health <= 0f)
        {
            if (Obstacle.enabled)
            {
                Obstacle.enabled = false;
            }

            _health = 0f;
        }

        if (_health == 0f && _plank[0].activeSelf)
        {
            _plank[0].SetActive(false);
        }

        if (_health <= 33f && _plank[1].activeSelf)
        {
            _plank[1].SetActive(false);
        }

        if (_health <= 67f && _plank[2].activeSelf)
        {
            _plank[2].SetActive(false);
        }

        UpdateHealthBar();
    }

    private void Repair()
    {
        _health += 0.5f;

        if (_health >= _maxHealth)
        {
            _health = _maxHealth;
        }

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

        UpdateHealthBar();
    }
}