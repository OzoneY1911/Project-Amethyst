using TMPro;
using UnityEngine;

public class TESTWeaponState : SingletonMono<TESTWeaponState>
{
    [SerializeField] private TextMeshProUGUI _stateBar;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        _stateBar.text = WeaponStateMachine.Instance.CurrentState.ToString();
    }
}