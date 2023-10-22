public class IdleWeaponState : WeaponState
{
    public override void Enter()
    {
        base.Enter();


    }

    public override void Update()
    {
        base.Update();

        _weaponStateMachine.CheckIfShooting();
        _weaponStateMachine.CheckIfReloading();
        _weaponStateMachine.CheckIfSwapping();
    }

    public override void Exit()
    {
        base.Exit();


    }
}