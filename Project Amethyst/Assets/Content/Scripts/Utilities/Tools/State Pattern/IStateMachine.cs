public interface IStateMachine
{
    public abstract void Init(IState initialState);
    public abstract void TransitionTo(IState nextState);
    public abstract void OnDestroy();
}