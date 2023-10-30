using UnityEngine;

public class WalkMovementState : MovementState
{
    public override void Enter()
    {
        base.Enter();

        _movementController.MovementSpeed = _movementController.WalkSpeed;
        _cameraController.WalkCamera.enabled = true;
    }

    public override void Update()
    {
        base.Update();

        _movementStateMachine.CheckIfIdle();
        _movementStateMachine.CheckIfRunning();

        _weaponSelector.CurrentWeaponObject.GetComponent<Animator>().SetFloat("Movement Blend", .5f, .25f, Time.deltaTime);
    }
    public override void Exit()
    {
        base.Exit();

        _cameraController.WalkCamera.enabled = false;
    }
}