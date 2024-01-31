using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class WeaponSelector : SingletonMono<WeaponSelector>
{
    protected static GameObject _currentWeaponObject => WeaponSelector.Instance.CurrentWeaponObject;
    private static WeaponController _weaponController => WeaponController.Instance;

    [Header("Weapon Holders")]
    [SerializeField] private Transform _pistolHolder;
    public Transform ShotgunHolder;
    public Transform RifleHolder;

    [Header("Weapon Lists")]
    [SerializeField] private List<WeaponSO> _pistolList = new List<WeaponSO>();
    public List<WeaponSO> ShotgunList = new List<WeaponSO>();
    public List<WeaponSO> RifleList = new List<WeaponSO>();

    public GameObject CurrentWeaponObject;
    public GameObject NextWeaponObject;

    [HideInInspector] public GameObject PistolObject;
    [HideInInspector] public GameObject ShotgunObject;
    [HideInInspector] public GameObject RifleObject;

    public WeaponSO CurrentWeapon;
    public WeaponSO NextWeapon;

    [HideInInspector] public WeaponSO CurrentPistol;
    [HideInInspector] public WeaponSO CurrentShotgun;
    [HideInInspector] public WeaponSO CurrentRifle;

    protected override void Awake()
    {
        base.Awake();

        CurrentPistol = _pistolList[0];
        Equip(CurrentPistol, _pistolHolder, out PistolObject);
        Draw(CurrentPistol, PistolObject);
    }

    public void Equip(in WeaponSO gun, in Transform holder, out GameObject gunObject)
    {
        gun.CurrentReserve = gun.DefaultReserve;
        gun.CurrentRounds = gun.MagazineSize;
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
        if (CurrentWeaponObject.GetComponent<Animator>() != null)
        {
            CurrentWeaponObject.GetComponent<Animator>().SetFloat("Draw Holster Speed", _weaponController.DrawHolsterMultiplier);
        }

        if (CurrentWeaponObject != null)
        {
            CurrentWeaponObject.SetActive(false);
        }
        CurrentWeapon = weapon;
        CurrentWeaponObject = weaponObject;
        CurrentWeaponObject.SetActive(true);

        if (CurrentWeaponObject.GetComponent<Animator>() != null)
        {
            if (CurrentWeapon.CurrentRounds > 0)
            {
                CurrentWeaponObject.GetComponent<Animator>().SetBool("Loaded", true);
            }
            else
            {
                CurrentWeaponObject.GetComponent<Animator>().SetBool("Loaded", false);
            }
        }

        StartCoroutine(DrawHolsterCooldown(true));
    }

    public void Holster()
    {

        if (CurrentWeaponObject.GetComponent<Animator>() != null)
        {
            CurrentWeaponObject.GetComponent<Animator>().SetFloat("Draw Holster Speed", _weaponController.DrawHolsterMultiplier);

            CurrentWeaponObject.GetComponent<Animator>().SetTrigger("Holster");
        }

        StartCoroutine(DrawHolsterCooldown(false));
    }

    private IEnumerator DrawHolsterCooldown(bool draw)
    {
        yield return new WaitForSeconds(CurrentWeapon.TimeDraw / _weaponController.DrawHolsterMultiplier);

        if (draw)
        {
            WeaponStateMachine.Instance.TransitionTo(WeaponStateMachine.Instance.WeaponIdle);
        }
        else
        {
            WeaponStateMachine.Instance.TransitionTo(WeaponStateMachine.Instance.WeaponDraw);
        }
    }
}