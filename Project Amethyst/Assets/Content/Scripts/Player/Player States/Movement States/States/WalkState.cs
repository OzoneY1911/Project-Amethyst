using UnityEngine;

public class WalkState : MovementState
{
    public override void Enter()
    {
        base.Enter();

        MovementController.Instance.MovementSpeed = MovementController.Instance.WalkSpeed;
        LookController.Instance.WalkCamera.enabled = true;
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

        LookController.Instance.WalkCamera.enabled = false;
    }
}