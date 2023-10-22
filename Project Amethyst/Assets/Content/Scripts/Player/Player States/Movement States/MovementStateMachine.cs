using UnityEngine;

public class MovementStateMachine : SingletonMono<MovementStateMachine>, IStateMachine
{
    public IState CurrentState { get; private set; }

    public IState MovementIdle;
    public IState MovementWalk;
    public IState MovementRun;
    public IState MovementAir;

    // FOR TESTING
    #if UNITY_EDITOR
    [SerializeField] private string _currentState;
    #endif

    private MovementStateMachine()
    {
        MovementIdle = new IdleMovementState();
        MovementWalk = new WalkMovementState();
        MovementRun = new RunMovementState();
        MovementAir = new AirMovementState();
    }

    protected override void Awake()
    {
        base.Awake();

        Init(MovementIdle);
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
        MovementIdle = null;
        MovementWalk = null;
        MovementRun = null;
        MovementAir = null;
    }

    public void CheckIfIdle()
    {
        if (InputManager.Instance.GetPlayerWalk() == Vector2.zero)
        {
            TransitionTo(MovementIdle);
        }
    }

    public void CheckIfWalking()
    {
        if (InputManager.Instance.GetPlayerWalk() != Vector2.zero)
        {
            TransitionTo(MovementWalk);
        }
    }

    public void CheckIfRunning()
    {
        if (InputManager.Instance.GetPlayerRun() && InputManager.Instance.GetPlayerWalk() != Vector2.zero)
        {
            TransitionTo(MovementRun);
        }
    }

    public void CheckIfNotRunning()
    {
        if (!InputManager.Instance.GetPlayerRun() || InputManager.Instance.GetPlayerWalk() == Vector2.zero)
        {
            TransitionTo(MovementWalk);
        }
    }

    public void CheckIfJumping()
    {
        if (MovementController.Instance.CheckGround && InputManager.Instance.GetPlayerJump())
        {
            TransitionTo(MovementAir);
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
