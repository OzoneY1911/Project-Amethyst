using TMPro;
using UnityEngine;

public class BigRedButton : SingletonMono<BigRedButton>
{
    private static InputManager _inputManager => InputManager.Instance;

    [SerializeField] private CanvasGroup _interactHint;
    [SerializeField] private TextMeshProUGUI _interactText;

    private bool _inRange;

    protected override void Awake()
    {
        base.Awake();
        
    }

    private void Update()
    {
        if (_inRange && _inputManager.GetPlayerInteract())
        {
            LevelLoader.Instance.LoadLevel("MainLevel");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _inRange = true;
            _interactText.text = "F to Interact";
            _interactHint.GetComponent<FadeCanvasGroup>().ShowCanvas();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _inRange = false;
            _interactHint.GetComponent<FadeCanvasGroup>().HideCanvas();
            _interactText.text = "F to Repair";
        }
    }
}