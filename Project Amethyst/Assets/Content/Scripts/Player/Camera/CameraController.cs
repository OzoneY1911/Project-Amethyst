using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(InputManager))]
public class CameraController : SingletonMono<CameraController>
{
    [SerializeField] private Camera _mainCamera;

    [SerializeField] private CinemachineVirtualCamera _idleCamera;
    [SerializeField] private CinemachineVirtualCamera _walkCamera;
    [SerializeField] private CinemachineVirtualCamera _runCamera;
    [SerializeField] private CinemachineVirtualCamera _airCamera;

    #region Properties

    public Camera MainCamera { get => _mainCamera; }

    public CinemachineVirtualCamera IdleCamera { get => _idleCamera; }
    public CinemachineVirtualCamera WalkCamera { get => _walkCamera; }
    public CinemachineVirtualCamera RunCamera { get => _runCamera; }
    public CinemachineVirtualCamera AirCamera { get => _airCamera; }

    #endregion

    protected override void Awake()
    {
        base.Awake();

    }

    public void DisableRotation()
    {
        _idleCamera.GetComponent<CinemachineInputProvider>().enabled = false;
        _walkCamera.GetComponent<CinemachineInputProvider>().enabled = false;
        _runCamera.GetComponent<CinemachineInputProvider>().enabled = false;
        _airCamera.GetComponent<CinemachineInputProvider>().enabled = false;
    }
    public void EnableRotation()
    {
        _idleCamera.GetComponent<CinemachineInputProvider>().enabled = true;
        _walkCamera.GetComponent<CinemachineInputProvider>().enabled = true;
        _runCamera.GetComponent<CinemachineInputProvider>().enabled = true;
        _airCamera.GetComponent<CinemachineInputProvider>().enabled = true;
    }
}
