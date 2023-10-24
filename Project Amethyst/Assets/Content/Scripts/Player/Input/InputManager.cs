using UnityEngine;

public class InputManager : SingletonMono<InputManager>
{
    private PlayerControls _playerControls;

    #region Basic Methods

    protected override void Awake()
    {
        base.Awake();

        _playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    private void OnDestroy()
    {
        _playerControls.Dispose();
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
