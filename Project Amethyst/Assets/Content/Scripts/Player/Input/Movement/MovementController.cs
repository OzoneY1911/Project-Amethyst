using UnityEngine;

[RequireComponent (typeof(CharacterController), typeof(InputManager))]
public class MovementController : SingletonMono<MovementController>
{
    private CharacterController _controller;
    private InputManager _inputManager;
    private CameraController _cameraController;
    private Vector3 _fallVelocity;

    [SerializeField] private float _walkSpeed = 2f;
    [SerializeField] private float _runSpeed = 5f;
    [SerializeField] private float _jumpHeight = 1f;
    [SerializeField] private float _jumpStrength = 3f;

    [SerializeField] private Transform _orientation;

    public float MovementSpeed { get; set; }
    public float WalkSpeed { get { return _walkSpeed; } }
    public float RunSpeed { get { return _runSpeed; } }

    #region Properties

    public bool CheckGround
    {
        get
        {
            return Physics.Raycast(transform.position, Vector3.down, (_controller.height / 2f) + 0.1f);
        }
    }

    public float FallVelocity
    {
        get
        {
            return _fallVelocity.y;
        }
    }

    #endregion

    protected override void Awake()
    {
        base.Awake();

        _controller = GetComponent<CharacterController>();
        _inputManager = GetComponent<InputManager>();
        _cameraController = GetComponent<CameraController>();
    }

    public void Move()
    {
        Vector3 move = new Vector3(_inputManager.GetPlayerWalk().x, 0f, _inputManager.GetPlayerWalk().y);
        _orientation.eulerAngles = new Vector3(0f, _cameraController.MainCamera.transform.localEulerAngles.y, 0f);
        move = (_orientation.forward * move.z + _orientation.right * move.x).normalized;

        _controller.Move(MovementSpeed * Time.deltaTime * move);
    }

    public void ApplyGravity()
    {
        _fallVelocity.y += Physics.gravity.y * Time.deltaTime;
        _controller.Move(_fallVelocity * Time.deltaTime);

        if (CheckGround && _fallVelocity.y < 0)
        {
            _fallVelocity.y = 0f;
        }
    }

    public void Jump()
    {
        _fallVelocity.y += Mathf.Sqrt(_jumpHeight * -_jumpStrength * Physics.gravity.y);
    }
}
