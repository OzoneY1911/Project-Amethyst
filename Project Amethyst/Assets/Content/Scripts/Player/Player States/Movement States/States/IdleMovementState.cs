public class IdleMovementState : MovementState
{
    public override void Enter()
    {
        base.Enter();

        _cameraController.IdleCamera.enabled = true;
    }

    public override void Update()
    {
        base.Update();

        _movementStateMachine.CheckIfWalking();
    }

    public override void Exit()
    {
        base.Exit();

        _cameraController.IdleCamera.enabled = false;
    }
}
