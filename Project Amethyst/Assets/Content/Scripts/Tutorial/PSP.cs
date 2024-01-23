using UnityEngine;
using TMPro;

public class PSP : SingletonMono<PSP>
{
    private static InputManager _inputManager => InputManager.Instance;

    [SerializeField] private CanvasGroup _interactHint;
    [SerializeField] private CanvasGroup HUD;
    [SerializeField] private TextMeshProUGUI _interactText; 

    private bool _inRange;
    public static bool PspOn;

    [SerializeField] private GameObject _pspObject;

    protected override void Awake()
    {
        base.Awake();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _inRange = true;
            _interactText.text = "F to Play";
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

    private void Update()
    {
        if (_inRange && _inputManager.GetPlayerInteract())
        {
            _inputManager.DisableInput(false);
            PspOn = true;
            _pspObject.SetActive(true);
            HUD.GetComponent<FadeCanvasGroup>().HideCanvas();
        }

        if (PspOn && _inputManager.GetUIClose())
        {
            TurnOff();
        }
    }

    public void TurnOff()
    {
        _pspObject.SetActive(false);
        _inputManager.EnableInput();
        HUD.GetComponent<FadeCanvasGroup>().ShowCanvas();
    }
}