using System.Collections;
using UnityEngine;

public class WindMill : MonoBehaviour
{
    [SerializeField] private Transform _blades;

    [SerializeField] private float _currentSpeed;

    private void FixedUpdate()
    {
        if (_currentSpeed != 0)
        {
            _blades.Rotate(0f, 0f, _currentSpeed);
        }
    }

    public void ChangeSpeed(float targetSpeed)
    {
        StartCoroutine(ChangeSpeedCoroutine(_currentSpeed, targetSpeed));
    }

    private IEnumerator ChangeSpeedCoroutine(float initialSpeed, float targetSpeed)
    {
        float t = 0f;
        while (t != 1f)
        {
            _currentSpeed = Mathf.Lerp(initialSpeed, targetSpeed, t);
            t += 0.05f;
            yield return null;
        }
    }
}