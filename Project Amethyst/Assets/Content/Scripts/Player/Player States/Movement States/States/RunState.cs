using UnityEngine;

public class RunState : MovementState
{
    public override void Enter()
    {
        base.Enter();

        MovementController.Instance.MovementSpeed = MovementController.Instance.RunSpeed;
        CameraController.Instance.RunCamera.enabled = true;
    }

    public override void Update()
    {
        base.Update();

        MovementStateMachine.Instance.CheckIfNotRunning();
    }
    public override void Exit()
    {
        base.Exit();

        CameraController.Instance.RunCamera.enabled = false;
    }
}