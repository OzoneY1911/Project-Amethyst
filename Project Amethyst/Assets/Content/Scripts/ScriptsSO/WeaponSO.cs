using UnityEngine;

public enum WeaponType
{
    Pistol,
    Shotgun,
    Rifle
}

[CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Object/Weapon")]
public class WeaponSO : ScriptableObject
{
    [Header("Prefab")]
    public GameObject Prefab;

    [Header("Core Information")]
    public string Name;
    public WeaponType Type;
    public bool IsAutomatic;

    [Header("Main Stats")]
    public int Damage;
    public float Rate;
    public float Range;

    [Header("Ammo")]
    public float ReloadTime;
    public int MagazineSize;
    public int DefaultReserve;
    public int MaxReserve;
    [HideInInspector] public int CurrentRounds;
    [HideInInspector] public int CurrentReserve;
    [HideInInspector] public bool CanShoot = true;
}