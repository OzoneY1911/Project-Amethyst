using TMPro;
using UnityEngine;

public class TESTStateBar : SingletonMono<TESTStateBar>
{
    [SerializeField] private TextMeshProUGUI _stateBar;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        _stateBar.text = MovementStateMachine.Instance.CurrentState.ToString();
    }
}