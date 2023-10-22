public class RunMovementState : MovementState
{
    public override void Enter()
    {
        base.Enter();

        _movementController.MovementSpeed = _movementController.RunSpeed;
        _cameraController.RunCamera.enabled = true;
    }

    public override void Update()
    {
        base.Update();

        _movementStateMachine.CheckIfNotRunning();
    }
    public override void Exit()
    {
        base.Exit();

        _cameraController.RunCamera.enabled = false;
    }
}