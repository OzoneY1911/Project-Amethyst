using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    [Header("Sway Settings")]
    [SerializeField] private float _smooth;
    [SerializeField] private float _swayMultiplier;

    void Update()
    {
        float mouseX = InputManager.Instance.GetPlayerLook().x * _swayMultiplier;
        float mouseY = InputManager.Instance.GetPlayerLook().y * _swayMultiplier;

        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

        Quaternion targetRotation = rotationX * rotationY;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, _smooth * Time.deltaTime);
    }
}