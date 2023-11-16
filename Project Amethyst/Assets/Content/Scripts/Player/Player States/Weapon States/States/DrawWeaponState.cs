public class DrawWeaponState : WeaponState
{
    public override void Enter()
    {
        base.Enter();

        if (!_weaponSelector.CurrentWeapon.CanShoot)
        {
            _weaponSelector.CurrentWeapon.CanShoot = true;
        }

        if (_weaponSelector.NextWeapon != null)
        {
            _weaponSelector.Draw(_weaponSelector.NextWeapon, _weaponSelector.NextWeaponObject);
        }
    }

    public override void Update()
    {
        base.Update();


    }

    public override void Exit()
    {
        base.Exit();


    }
}