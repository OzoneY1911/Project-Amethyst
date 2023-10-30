using UnityEngine;

public abstract class MovementState : IState
{
    protected static CameraController _cameraController => CameraController.Instance;
    protected static MovementController _movementController => MovementController.Instance;
    protected static MovementStateMachine _movementStateMachine => MovementStateMachine.Instance;
    protected static WeaponSelector _weaponSelector => WeaponSelector.Instance;

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
}
