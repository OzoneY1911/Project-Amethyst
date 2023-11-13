public class HolsterWeaponState : WeaponState
{
    public override void Enter()
    {
        base.Enter();

        _weaponSelector.Holster();
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