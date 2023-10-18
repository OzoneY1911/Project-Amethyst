public class AirState : MovementState
{
    public override void Enter()
    {
        base.Enter();

        MovementController.Instance.Jump();
        CameraController.Instance.AirCamera.enabled = true;
    }

    public override void Update()
    {
        base.Update();

        MovementStateMachine.Instance.CheckIfLanded();
    }

    public override void Exit()
    {
        base.Exit();

        CameraController.Instance.AirCamera.enabled = false;
    }
}