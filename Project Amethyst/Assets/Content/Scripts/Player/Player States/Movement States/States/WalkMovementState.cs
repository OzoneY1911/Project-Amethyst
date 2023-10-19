public class WalkMovementState : MovementState
{
    public override void Enter()
    {
        base.Enter();

        MovementController.Instance.MovementSpeed = MovementController.Instance.WalkSpeed;
        CameraController.Instance.WalkCamera.enabled = true;
    }

    public override void Update()
    {
        base.Update();

        MovementStateMachine.Instance.CheckIfIdle();
        MovementStateMachine.Instance.CheckIfRunning();
    }
    public override void Exit()
    {
        base.Exit();

        CameraController.Instance.WalkCamera.enabled = false;
    }
}