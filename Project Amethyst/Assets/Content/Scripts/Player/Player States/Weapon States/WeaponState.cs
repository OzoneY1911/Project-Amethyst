using UnityEngine;

public abstract class WeaponState : IState
{
    protected static InputManager _inputManager => InputManager.Instance;
    protected static WeaponController _weaponController => WeaponController.Instance;
    protected static WeaponSelector _weaponSelector => WeaponSelector.Instance;
    protected static WeaponStateMachine _weaponStateMachine => WeaponStateMachine.Instance;
    protected static GameObject _currentWeaponObject => WeaponSelector.Instance.CurrentWeaponObject;

    public virtual void Enter()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void Exit()
    {

    }
}
