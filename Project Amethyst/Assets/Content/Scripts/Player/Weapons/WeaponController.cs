using System.Collections;
using UnityEngine;

public class WeaponController : SingletonMono<WeaponController>
{
    private static Transform _cameraTransform => CameraController.Instance.MainCamera.transform;
    private static WeaponSO _currentWeapon => WeaponSelector.Instance.CurrentWeapon;

    private Coroutine _reloadCoroutine;
    private bool _reloading;

    public void Shoot()
    {
        _currentWeapon.CurrentRounds--;

        RaycastHit hit;
        if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out hit, _currentWeapon.Range))
        {
            
        }

        StartCoroutine(ShootCooldown());
    }

    private IEnumerator ShootCooldown()
    {
        _currentWeapon.CanShoot = false;

        yield return new WaitForSeconds(60f / _currentWeapon.Rate);

        _currentWeapon.CanShoot = true;
    }

    public void Reload()
    {
        if (_reloading)
        {
            StopCoroutine(_reloadCoroutine);
        }

        _reloadCoroutine = StartCoroutine(ReloadCooldown());
    }

    public void ReloadInterrupt()
    {
        StopCoroutine(_reloadCoroutine);
    }

    private IEnumerator ReloadCooldown()
    {
        _reloading = true;
        _currentWeapon.CanShoot = false;

        yield return new WaitForSeconds(_currentWeapon.ReloadTime);
        
        var roundsNeeded = _currentWeapon.MagazineSize - _currentWeapon.CurrentRounds;
        if (_currentWeapon.CurrentRounds >= _currentWeapon.CurrentReserve)
        {
            _currentWeapon.CurrentRounds += roundsNeeded;
            _currentWeapon.CurrentReserve -= roundsNeeded;
        }
        else
        {
            _currentWeapon.CurrentRounds += _currentWeapon.CurrentReserve;
            _currentWeapon.CurrentReserve = 0;
        }

        _currentWeapon.CanShoot = true;
        _reloading = false;
    }
}