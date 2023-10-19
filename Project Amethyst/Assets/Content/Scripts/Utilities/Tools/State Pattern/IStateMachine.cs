public interface IStateMachine
{
    public abstract void Init(in IState initialState);
    public abstract void TransitionTo(in IState nextState);
    public abstract void OnDestroy();
}