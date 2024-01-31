using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class MovementState : IState
{
    protected static CameraController _cameraController => CameraController.Instance;
    protected static MovementController _movementController => MovementController.Instance;
    protected static MovementStateMachine _movementStateMachine => MovementStateMachine.Instance;

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
        if (SceneManager.GetActiveScene().name != "TutorialLevel")
        {
            if (WeaponSelector.Instance.CurrentWeaponObject.GetComponent<Animator>() != null)
            {
                if (WeaponSelector.Instance.CurrentWeaponObject.GetComponent<Animator>().GetFloat("Movement Blend") != target)
                {
                    WeaponSelector.Instance.CurrentWeaponObject.GetComponent<Animator>().SetFloat("Movement Blend", target, speed, Time.deltaTime);
                }
            }
        }
    }
}
