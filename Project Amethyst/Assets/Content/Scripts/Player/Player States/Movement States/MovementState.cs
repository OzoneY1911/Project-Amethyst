public abstract class MovementState : IState
{
    public virtual void Enter()
    {

    }

    public virtual void Update()
    {
        MovementStateMachine.Instance.CheckIfJumping();
    }

    public virtual void Exit()
    {

    }
}
