using UnityEngine;

public abstract class MovementState : IState
{
    protected static CameraController _cameraController => CameraController.Instance;
    protected static MovementController _movementController => MovementController.Instance;
    protected static MovementStateMachine _movementStateMachine => MovementStateMachine.Instance;
    protected static GameObject _currentWeaponObject => WeaponSelector.Instance.CurrentWeaponObject;

    public virtual void Enter()
    {

    }

    public virtual void Update()
    {
        _movementController.Move();
        _movementController.ApplyGravity();
        _movementStateMachine.CheckIfJumping();
    }

    public virtual void Exit()
    {

    }

    protected void SetAnimatorFloat(in float target, in float speed)
    {
        if (_currentWeaponObject.GetComponent<Animator>().GetFloat("Movement Blend") != target)
        {
            _currentWeaponObject.GetComponent<Animator>().SetFloat("Movement Blend", target, speed, Time.deltaTime);
        }
    }
}
