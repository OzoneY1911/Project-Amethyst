using UnityEngine;

public class WindMill : MonoBehaviour
{
    [SerializeField] private Transform _blades;

    [SerializeField] private float _rotationSpeed;

    private void FixedUpdate()
    {
        if (_rotationSpeed != 0)
        {
            _blades.Rotate(0f, 0f, _rotationSpeed);
        }
    }
}