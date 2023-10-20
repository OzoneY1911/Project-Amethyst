public class ShotWeaponState : WeaponState
{
    public override void Enter()
    {
        base.Enter();


    }

    public override void Update()
    {
        base.Update();

        WeaponStateMachine.Instance.CheckIfShooting();
    }

    public override void Exit()
    {
        base.Exit();


    }
}