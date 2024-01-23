using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : SingletonMono<InputManager>
{
    public PlayerControls _playerControls;
    protected static CameraController _cameraController => CameraController.Instance;

    #region Basic Methods

    protected override void Awake()
    {
        base.Awake();

        _playerControls = new PlayerControls();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        _playerControls.Enable();

        _playerControls.UI.Disable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    private void OnDestroy()
    {
        _playerControls.Dispose();
    }

    public void EnableInput()
    {
        _playerControls.UI.Disable();
        _playerControls.Player.Enable();
        _cameraController.EnableRotation();

        if (Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void DisableInput(in bool enableCursor = true)
    {
        _playerControls.Player.Disable();
        _playerControls.UI.Enable();
        _cameraController.DisableRotation();

        if (enableCursor)
        {
            Cursor.lockState = CursorLockMode.None;   
        }
    }

    #endregion

    #region Common Input

    public bool GetPlayerInteract()
    {
        return _playerControls.Player.Interact.IsPressed();
    }

    public bool GetPlayerPause()
    {
        return _playerControls.Player.PauseMenu.IsPressed();
    }

    public bool GetUIEscape()
    {
        return _playerControls.UI.EscapeUI.IsPressed();
    }

    public bool GetUIClose()
    {
        return _playerControls.UI.CloseUI.IsPressed();
    }

    public bool GetUILeft()
    {
        return _playerControls.UI.Left.WasPressedThisFrame();
    }
    public bool GetUIUp()
    {
        return _playerControls.UI.Up.WasPressedThisFrame();
    }
    public bool GetUIRight()
    {
        return _playerControls.UI.Right.WasPressedThisFrame();
    }

    #endregion

    #region Movement Input

    public Vector2 GetPlayerWalk()
    {
        return _playerControls.Player.Walk.ReadValue<Vector2>();
    }

    public bool GetPlayerRun()
    {
        return _playerControls.Player.Run.IsPressed();
    }

    public bool GetPlayerJump()
    {
        return _playerControls.Player.Jump.WasPressedThisFrame();
    }

    public Vector2 GetPlayerLook()
    {
        return _playerControls.Player.Look.ReadValue<Vector2>();
    }

    #endregion

    #region Weapon Input

    public bool GetPlayerShot(in bool isAutomatic)
    {
        if (isAutomatic)
        {
            return _playerControls.Player.Shot.IsPressed();
        }
        else
        {
            return _playerControls.Player.Shot.WasPressedThisFrame();
        }
    }

    public bool GetPlayerReload()
    {
        return _playerControls.Player.Reload.IsPressed();
    }

    public bool GetPlayerDrawPistol()
    {
        return _playerControls.Player.DrawPistol.WasPressedThisFrame();
    }
    public bool GetPlayerDrawShotgun()
    {
        return _playerControls.Player.DrawShotgun.WasPressedThisFrame();
    }
    public bool GetPlayerDrawRifle()
    {
        return _playerControls.Player.DrawRifle.WasPressedThisFrame();
    }

    #endregion
}
