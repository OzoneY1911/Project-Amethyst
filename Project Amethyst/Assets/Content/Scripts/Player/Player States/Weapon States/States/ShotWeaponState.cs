public class ShotWeaponState : WeaponState
{
    public override void Enter()
    {
        base.Enter();

        _weaponController.Shoot();
    }

    public override void Update()
    {
        base.Update();

        _weaponStateMachine.CheckIfShooting();
    }

    public override void Exit()
    {
        base.Exit();


    }
}