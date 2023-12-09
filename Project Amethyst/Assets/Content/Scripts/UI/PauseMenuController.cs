using UnityEngine;

public class PauseMenuController : MenuController
{
    protected static InputManager _inputManager => InputManager.Instance;

    [SerializeField] private GameObject _pauseMenu;

    private bool _paused;

    private void Update()
    {
        if (_inputManager.GetPlayerPause() && !_paused)
        {
            Pause();
        }
        else if (_inputManager.GetUIEscape() && _paused)
        {
            Resume();
        }
    }

    private void Pause()
    {
        _paused = true;
        _inputManager.DisableInput();
        _pauseMenu.GetComponent<FadeCanvasGroup>().ShowCanvas();
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        _paused = false;
        _inputManager.EnableInput();
        _pauseMenu.GetComponent<FadeCanvasGroup>().HideCanvas();
        Time.timeScale = 1f;
    }
}