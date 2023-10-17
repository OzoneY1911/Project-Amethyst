using UnityEngine;

public class RunState : MovementState
{
    public override void Enter()
    {
        base.Enter();

        MovementController.Instance.MovementSpeed = MovementController.Instance.RunSpeed;
        LookController.Instance.RunCamera.enabled = true;
    }

    public override void Update()
    {
        base.Update();

        MovementStateMachine.Instance.CheckIfNotRunning();
    }
    public override void Exit()
    {
        base.Exit();

        LookController.Instance.RunCamera.enabled = false;
    }
}