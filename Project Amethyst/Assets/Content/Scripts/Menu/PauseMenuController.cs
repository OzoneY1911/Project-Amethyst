using UnityEngine;

public class PauseMenuController : MenuController
{
    protected static InputManager _inputManager => InputManager.Instance;
    protected static CameraController _cameraController => CameraController.Instance;

    [SerializeField] private GameObject _pauseMenu;

    protected override void Awake()
    {
        base.Awake();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (_inputManager.GetPlayerPause())
        {
            Pause();
        }
        else if (_inputManager.GetPlayerEscape())
        {
            Resume();
        }
    }

    private void Pause()
    {
        _inputManager._playerControls.Player.Disable();
        _inputManager._playerControls.UI.Enable();
        _cameraController.DisableRotation();

        _pauseMenu.GetComponent<FadeCanvasGroup>().ShowCanvas();
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        _inputManager._playerControls.UI.Disable();
        _inputManager._playerControls.Player.Enable();
        _cameraController.EnableRotation();

        _pauseMenu.GetComponent<FadeCanvasGroup>().HideCanvas();
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }
}