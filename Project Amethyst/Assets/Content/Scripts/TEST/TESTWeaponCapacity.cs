using TMPro;
using UnityEngine;

public class TESTWeaponCapacity : SingletonMono<TESTWeaponCapacity>
{
    [SerializeField] private TextMeshProUGUI _ammo;


    protected override void Awake()
    {
        base.Awake();
        
    }

    private void Update()
    {
        _ammo.text = $"{WeaponSelector.Instance.CurrentWeapon.CurrentRounds} | {WeaponSelector.Instance.CurrentWeapon.CurrentReserve}";
    }
}