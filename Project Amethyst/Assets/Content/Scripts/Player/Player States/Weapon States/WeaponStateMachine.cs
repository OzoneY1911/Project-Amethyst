using UnityEngine;

public class WeaponStateMachine : SingletonMono<WeaponStateMachine>, IStateMachine
{
    public IState CurrentState { get; private set; }

    public IState WeaponIdle;
    public IState WeaponShot;
    public IState WeaponReload;

    // FOR TESTING
    #if UNITY_EDITOR
    [SerializeField] private string _currentState;
    #endif

    private WeaponStateMachine()
    {
        WeaponIdle = new IdleWeaponState();
        WeaponShot = new ShotWeaponState();
        WeaponReload = new ReloadWeaponState();
    }

    protected override void Awake()
    {
        base.Awake();

        Init(WeaponIdle);
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
        WeaponIdle = null;
        WeaponShot = null;
        WeaponReload = null;
    }

    public void CheckIfShooting()
    {
        if (InputManager.Instance.GetPlayerShot())
        {
            TransitionTo(WeaponShot);
        }
        else
        {
            {
                TransitionTo(WeaponIdle);
            }
        }
    }
}
