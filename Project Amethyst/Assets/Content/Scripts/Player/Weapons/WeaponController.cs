using System.Collections;
using System.Timers;
using UnityEngine;

public class WeaponController : SingletonMono<WeaponController>
{
    private static Transform _cameraTransform => CameraController.Instance.MainCamera.transform;
    private static WeaponSO _currentWeapon => WeaponSelector.Instance.CurrentWeapon;

    private Coroutine _reloadCoroutine;
    private bool _reloading;

    #region Shooting

    // SHOOTING

    public void Shoot()
    {
        _currentWeapon.CurrentRounds--;

        RaycastHit hit;
        if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out hit, _currentWeapon.Range))
        {
            if (hit.collider.tag == "Enemy")
            {
                hit.collider.GetComponent<EnemyHealth>().ChangeHealth(-_currentWeapon.Damage);
            }
        }

        StartCoroutine(ShootCooldown());
    }

    private IEnumerator ShootCooldown()
    {
        _currentWeapon.CanShoot = false;

        yield return new WaitForSeconds(60f / _currentWeapon.Rate);

        _currentWeapon.CanShoot = true;
    }

    #endregion

    #region Reloading

    // RELOADING

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

        var roundsLacking = _currentWeapon.MagazineSize - _currentWeapon.CurrentRounds;

        if (roundsLacking <= _currentWeapon.CurrentReserve)
        {
            if (_currentWeapon.CurrentRounds != 0 && _currentWeapon.RoundInChamber)
            {
                _currentWeapon.CurrentReserve -= roundsLacking + 1;
                _currentWeapon.CurrentRounds = _currentWeapon.MagazineSize + 1;
            }
            else
            {
                _currentWeapon.CurrentReserve -= roundsLacking;
                _currentWeapon.CurrentRounds = _currentWeapon.MagazineSize;
            }
        }
        else
        {
            _currentWeapon.CurrentRounds += _currentWeapon.CurrentReserve;
            _currentWeapon.CurrentReserve = 0;
        }

        _currentWeapon.CanShoot = true;
        _reloading = false;
    }

    #endregion
}