using UnityEngine;

public class MovementStateMachine : SingletonMono<MovementStateMachine>, IStateMachine
{
    public IState CurrentState { get; private set; }

    public IState Idle;
    public IState Walk;
    public IState Run;
    public IState Air;

    // FOR TESTING
    #if UNITY_EDITOR
    [SerializeField] private string _currentState;
    #endif

    private MovementStateMachine()
    {
        Idle = new IdleMovementState();
        Walk = new WalkMovementState();
        Run = new RunMovementState();
        Air = new AirMovementState();
    }

    protected override void Awake()
    {
        base.Awake();

        Init(Idle);
    }

    private void Update()
    {
        // FOR TESTING
        #if UNITY_EDITOR
        _currentState = CurrentState.ToString();
        #endif

        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }

    public void Init(in IState initialState)
    {
        CurrentState = initialState;
        initialState.Enter();
    }

    public void TransitionTo(in IState nextState)
    {
        CurrentState.Exit();
        CurrentState = nextState;
        CurrentState.Enter();
    }

    public void OnDestroy()
    {
        Idle = null;
        Walk = null;
        Run = null;
        Air = null;
    }

    public void CheckIfIdle()
    {
        if (InputManager.Instance.GetPlayerWalk() == Vector2.zero)
        {
            TransitionTo(Idle);
        }
    }

    public void CheckIfWalking()
    {
        if (InputManager.Instance.GetPlayerWalk() != Vector2.zero)
        {
            TransitionTo(Walk);
        }
    }

    public void CheckIfRunning()
    {
        if (InputManager.Instance.GetPlayerRun() && InputManager.Instance.GetPlayerWalk() != Vector2.zero)
        {
            TransitionTo(Run);
        }
    }

    public void CheckIfNotRunning()
    {
        if (!InputManager.Instance.GetPlayerRun() || InputManager.Instance.GetPlayerWalk() == Vector2.zero)
        {
            TransitionTo(Walk);
        }
    }

    public void CheckIfJumping()
    {
        if (MovementController.Instance.CheckGround && InputManager.Instance.GetPlayerJump())
        {
            TransitionTo(Air);
        }
    }

    public void CheckIfLanded()
    {
        if (MovementController.Instance.CheckGround && (MovementController.Instance.FallVelocity <= 0f))
        {
            CheckIfIdle();
            CheckIfWalking();
            CheckIfRunning();
        }
    }
}
