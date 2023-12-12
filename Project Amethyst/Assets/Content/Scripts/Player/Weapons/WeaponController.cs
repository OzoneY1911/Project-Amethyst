using System.Collections;
using UnityEngine;

// This class describes methods which contain actual actions for weapon features.
public class WeaponController : SingletonMono<WeaponController>
{
    private static Transform _cameraTransform => CameraController.Instance.MainCamera.transform;
    private static WeaponSO _currentWeapon => WeaponSelector.Instance.CurrentWeapon;
    protected static GameObject _currentWeaponObject => WeaponSelector.Instance.CurrentWeaponObject;

    private Coroutine _reloadCoroutine;
    private bool _reloading;
    private bool _fullReload;

    public int ReloadMultiplier = 1;
    public int DamageMultiplier = 1;

    #region Shooting

    // SHOOTING

    public void Shoot()
    {
        if (_currentWeapon.CurrentRounds != 1)
        {
            _currentWeaponObject.GetComponent<Animator>().SetTrigger("Shot");
        }
        else
        {
            _currentWeaponObject.GetComponent<Animator>().SetTrigger("Last Shot");
            _currentWeaponObject.GetComponent<Animator>().SetBool("Loaded", false);
        }

        _currentWeapon.CurrentRounds--;

        RaycastHit hit;
        if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out hit, _currentWeapon.Range))
        {
            if (hit.collider.tag == "Enemy")
            {
                hit.collider.GetComponent<EnemyHealth>().ChangeHealth(-_currentWeapon.Damage * DamageMultiplier);
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

        // Weapon has ammo in mag and chamber
        if (_currentWeapon.CurrentRounds != 0)
        {
            // Reload_Part
            if (_fullReload)
            {
                _fullReload = !_fullReload;
            }
        }
        // No ammo left in mag
        else
        {
            // Reload_Full
            if (!_fullReload)
            {
                _fullReload = !_fullReload;
            }
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

        _currentWeaponObject.GetComponent<Animator>().SetTrigger("Reload");

        yield return new WaitForSeconds(_currentWeapon.ReloadTime / ReloadMultiplier);

        var roundsLacking = _currentWeapon.MagazineSize - _currentWeapon.CurrentRounds;

        // Sufficient ammo in reserve
        if (roundsLacking < _currentWeapon.CurrentReserve)
        {
            if (!_fullReload)
            {
                // Reload_Part
                if (_currentWeapon.RoundInChamber)
                {
                    _currentWeapon.CurrentReserve -= roundsLacking + 1;
                    _currentWeapon.CurrentRounds = _currentWeapon.MagazineSize + 1;
                }
                else
                {
                    _currentWeapon.CurrentReserve -= roundsLacking;
                    _currentWeapon.CurrentRounds = _currentWeapon.MagazineSize;
                }
                Debug.Log("Part Reload");
            }
            else
            {
                // Reload_Full
                _currentWeapon.CurrentReserve -= roundsLacking;
                _currentWeapon.CurrentRounds = _currentWeapon.MagazineSize;
                Debug.Log("Full Reload");
            }
        }
        // Insufficient ammo in reserve
        else
        {
            // Load last ammo from reserve
            _currentWeapon.CurrentRounds += _currentWeapon.CurrentReserve;
            _currentWeapon.CurrentReserve = 0;
            Debug.Log("Last ammo loaded");
        }

        _currentWeapon.CanShoot = true;
        _reloading = false;
    }

    #endregion
}