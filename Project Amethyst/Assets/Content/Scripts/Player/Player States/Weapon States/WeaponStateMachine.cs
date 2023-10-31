using UnityEngine;

public class WeaponStateMachine : SingletonMono<WeaponStateMachine>, IStateMachine
{
    private static InputManager _inputManager => InputManager.Instance;
    private static WeaponSO _currentWeapon => WeaponSelector.Instance.CurrentWeapon;

    public IState CurrentState { get; private set; }

    public IState WeaponIdle;
    public IState WeaponShot;
    public IState WeaponReload;
    public IState WeaponDrawHolster;

    // FOR TESTING ---
#if UNITY_EDITOR
    [SerializeField] private string _currentState;
    #endif

    private WeaponStateMachine()
    {
        WeaponIdle = new IdleWeaponState();
        WeaponShot = new ShotWeaponState();
        WeaponReload = new ReloadWeaponState();
        WeaponDrawHolster = new DrawHolsterWeaponState();
    }

    protected override void Awake()
    {
        base.Awake();


    }

    private void Start()
    {
        Init(WeaponDrawHolster);
    }

    private void Update()
    {
        // FOR TESTING ---
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
        WeaponDrawHolster = null;
    }

    public void CheckIfShooting()
    {   
        if (_currentWeapon.CanShoot)
        {
            if (_inputManager.GetPlayerShot(_currentWeapon.IsAutomatic) && _currentWeapon.CurrentRounds > 0)
            {
                TransitionTo(WeaponShot);
            }
            else
            {
                if (CurrentState != WeaponIdle)
                {
                    TransitionTo(WeaponIdle);
                }
            }
        }
    }

    public void CheckIfReloading()
    {
        if (_inputManager.GetPlayerReload())
        {
            if ((_currentWeapon.CurrentRounds < _currentWeapon.MagazineSize) || (_currentWeapon.CurrentRounds == _currentWeapon.MagazineSize && _currentWeapon.RoundInChamber) && _currentWeapon.CurrentReserve > 0)
            {
                TransitionTo(WeaponReload);
            }
        }
    }

    public void CheckIfSwapping()
    {
        if (_inputManager.GetPlayerDrawPistol() && _currentWeapon.Type != WeaponType.Pistol)
        {
            TransitionTo(WeaponDrawHolster);
        }
        else if (_inputManager.GetPlayerDrawShotgun() && _currentWeapon.Type != WeaponType.Shotgun)
        {
            TransitionTo(WeaponDrawHolster);
        }
        else if (_inputManager.GetPlayerDrawRifle() && _currentWeapon.Type != WeaponType.Rifle)
        {
            TransitionTo(WeaponDrawHolster);
        }
    }
}
