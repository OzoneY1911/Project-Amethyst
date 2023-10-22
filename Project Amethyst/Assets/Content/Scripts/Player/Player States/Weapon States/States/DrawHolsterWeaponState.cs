public class DrawHolsterWeaponState : WeaponState
{
    public override void Enter()
    {
        base.Enter();

        if (!_weaponSelector.CurrentWeapon.CanShoot)
        {
            _weaponSelector.CurrentWeapon.CanShoot = true;
        }

        if (_inputManager.GetPlayerDrawPistol())
        {
            _weaponSelector.Draw(_weaponSelector.CurrentPistol, _weaponSelector.PistolObject);
        }
        else if (_inputManager.GetPlayerDrawShotgun())
        {
            _weaponSelector.Draw(_weaponSelector.CurrentShotgun, _weaponSelector.ShotgunObject);
        }
        else if (_inputManager.GetPlayerDrawRifle())
        {
            _weaponSelector.Draw(_weaponSelector.CurrentRifle, _weaponSelector.RifleObject);
        }
    }

    public override void Update()
    {
        base.Update();

        _weaponStateMachine.TransitionTo(_weaponStateMachine.WeaponIdle);
    }

    public override void Exit()
    {
        base.Exit();


    }
}