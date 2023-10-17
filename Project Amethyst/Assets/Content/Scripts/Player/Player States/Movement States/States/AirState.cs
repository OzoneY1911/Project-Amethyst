public class AirState : MovementState
{
    public override void Enter()
    {
        base.Enter();

        MovementController.Instance.Jump();
        LookController.Instance.AirCamera.enabled = true;
    }

    public override void Update()
    {
        MovementStateMachine.Instance.CheckIfLanded();
    }

    public override void Exit()
    {
        base.Exit();

        LookController.Instance.AirCamera.enabled = false;
    }
}