public abstract class MovementState : IState
{
    public virtual void Enter()
    {

    }

    public virtual void Update()
    {
        MovementController.Instance.Move();
        MovementController.Instance.ApplyGravity();

        MovementStateMachine.Instance.CheckIfJumping();
    }

    public virtual void Exit()
    {

    }
}
