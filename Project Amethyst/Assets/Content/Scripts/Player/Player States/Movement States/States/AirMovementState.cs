public class AirMovementState : MovementState
{
    public override void Enter()
    {
        base.Enter();

        _movementController.Jump();
        _cameraController.AirCamera.enabled = true;
    }

    public override void Update()
    {
        base.Update();

        _movementStateMachine.CheckIfLanded();
    }

    public override void Exit()
    {
        base.Exit();

        _cameraController.AirCamera.enabled = false;
    }
}