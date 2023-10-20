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
        return _playerControls.Player.Jump.triggered;
    }

    public Vector2 GetPlayerLook()
    {
        return _playerControls.Player.Look.ReadValue<Vector2>();
    }

    #endregion

    #region Weapon Input

    public bool GetPlayerShot()
    {
        return _playerControls.Player.Shot.IsPressed();
    }

    public bool GetPlayerReload()
    {
        return _playerControls.Player.Reload.IsPressed();
    }

    #endregion

}
