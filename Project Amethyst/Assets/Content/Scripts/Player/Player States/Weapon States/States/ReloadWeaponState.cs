public class ReloadWeaponState : WeaponState
{
    public override void Enter()
    {
        base.Enter();

        _weaponController.Reload();
    }

    public override void Update()
    {
        base.Update();

        _weaponStateMachine.CheckIfSwapping();

        if (_weaponSelector.CurrentWeapon.CanShoot)
        {
            _weaponStateMachine.TransitionTo(_weaponStateMachine.WeaponIdle);
        }
    }

    public override void Exit()
    {
        base.Exit();

        if (!_weaponSelector.CurrentWeapon.CanShoot)
        {
            _weaponController.ReloadInterrupt();
        }
    }
}