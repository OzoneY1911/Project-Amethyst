using System.Collections;
using UnityEngine;

public abstract class ShopController : MonoBehaviour
{
    #region Class References

    protected static InputManager _inputManager => InputManager.Instance;
    protected static InteractHint _interactHint => InteractHint.Instance;
    protected static PlayerCurrency _playerCurrency => PlayerCurrency.Instance;

    #endregion

    [SerializeField] private CanvasGroup _shopCanvasGroup;
    [SerializeField] protected CanvasGroup _failedCanvasGroup;

    private bool _canOpen;
    private bool _shopOpen;

    protected Currency _playerShopCurrency;

    protected Coroutine _failCoroutine;
    protected bool _showingFail;

    private void Update()
    {
        if (_canOpen)
        {
            if (_inputManager.GetPlayerInteract())
            {
                OpenShop();
            }
        }

        if (_shopOpen)
        {
            if (_inputManager.GetUIClose() || _inputManager.GetUIEscape())
            {
                CloseShop();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canOpen = true;
            _interactHint.HintText = "Press F to Interact";
            _interactHint.GetComponent<FadeCanvasGroup>().ShowCanvas();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canOpen = false;

            _interactHint.GetComponent<FadeCanvasGroup>().HideCanvas();
        }
    }

    private void OpenShop()
    {
        _canOpen = false;
        _shopOpen = true;
        _inputManager.DisableInput();
        _shopCanvasGroup.GetComponent<FadeCanvasGroup>().ShowCanvas();

        _interactHint.GetComponent<FadeCanvasGroup>().HideCanvas();
    }

    public void CloseShop()
    {
        _shopOpen = false;
        _canOpen = true;
        _inputManager.EnableInput();
        _shopCanvasGroup.GetComponent<FadeCanvasGroup>().HideCanvas();

        _interactHint.GetComponent<FadeCanvasGroup>().ShowCanvas();

        if (_showingFail)
        {
            StopCoroutine(_failCoroutine);
            _failedCanvasGroup.GetComponent<FadeCanvasGroup>().HideCanvas();
        }
    }

    protected bool CheckPrice(int price)
    {
        if (_playerShopCurrency.Amount >= price)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected IEnumerator FailPurchase()
    {
        _showingFail = true;
        _failedCanvasGroup.GetComponent<FadeCanvasGroup>().ShowCanvas();
        yield return new WaitForSeconds(5f);
        _failedCanvasGroup.GetComponent<FadeCanvasGroup>().HideCanvas();
        _showingFail = false;
    }
}