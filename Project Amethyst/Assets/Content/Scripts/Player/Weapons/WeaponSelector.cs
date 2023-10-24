using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : SingletonMono<WeaponSelector>
{
    [Header("Weapon Holders")]
    [SerializeField] private Transform _pistolHolder;
    [SerializeField] private Transform _shotgunHolder;
    [SerializeField] private Transform _rifleHolder;

    [Header("Weapon Lists")]
    [SerializeField] private List<WeaponSO> _pistolList = new List<WeaponSO>();
    [SerializeField] private List<WeaponSO> _shotgunList = new List<WeaponSO>();
    [SerializeField] private List<WeaponSO> _rifleList = new List<WeaponSO>();

    private GameObject _currentWeaponObject;

    [HideInInspector] public GameObject PistolObject;
    [HideInInspector] public GameObject ShotgunObject;
    [HideInInspector] public GameObject RifleObject;

    public WeaponSO CurrentWeapon;

    [HideInInspector] public WeaponSO CurrentPistol;
    [HideInInspector] public WeaponSO CurrentShotgun;
    [HideInInspector] public WeaponSO CurrentRifle;

    protected override void Awake()
    {
        base.Awake();

        CurrentPistol = _pistolList[0];
        Equip(CurrentPistol, _pistolHolder, out PistolObject);
        Draw(CurrentPistol, PistolObject);

        CurrentShotgun = _shotgunList[0];
        Equip(CurrentShotgun, _shotgunHolder, out ShotgunObject);
        CurrentRifle = _rifleList[0];
        Equip(CurrentRifle, _rifleHolder, out RifleObject);

        CurrentPistol.CurrentReserve = CurrentPistol.DefaultReserve;
        CurrentShotgun.CurrentReserve = CurrentShotgun.DefaultReserve;
        CurrentRifle.CurrentReserve = CurrentRifle.DefaultReserve;
    }

    public void Equip(in WeaponSO gun, in Transform holder, out GameObject gunObject)
    {
        gunObject = Instantiate(gun.Prefab, holder);
        if (gunObject.activeSelf)
        {
            gunObject.SetActive(false);
        }
    }

    public void Unequip(in GameObject gunObject)
    {
        Destroy(gunObject);
    }

    public void Draw(in WeaponSO weapon, in GameObject weaponObject)
    {
        if (_currentWeaponObject != null)
        {
            _currentWeaponObject.SetActive(false);
        }
        CurrentWeapon = weapon;
        _currentWeaponObject = weaponObject;
        _currentWeaponObject.SetActive(true);
    }
}