public class IdleState : MovementState
{
    public override void Enter()
    {
        base.Enter();

        LookController.Instance.IdleCamera.enabled = true;
    }

    public override void Update()
    {
        base.Update();

        MovementStateMachine.Instance.CheckIfWalking();
    }

    public override void Exit()
    {
        base.Exit();

        LookController.Instance.IdleCamera.enabled = false;
    }
}
