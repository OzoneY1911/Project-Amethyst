using UnityEditor.Animations;
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
    public bool RoundInChamber;

    [Header("Main Stats")]
    public int Damage;
    public float Rate;
    public float Range;

    [Header("Ammo")]
    public float ReloadTime;
    public int MagazineSize;
    public int DefaultReserve;
    public int MaxReserve;

    [Header("Animation")]
    public AnimationClip AnimDraw;
    public AnimationClip AnimIdle;
    public AnimationClip AnimWalk;
    public AnimationClip AnimRun;
    public AnimationClip AnimShot;
    public AnimationClip AnimReloadPart;
    public AnimationClip AnimReloadFull;
    public AnimationClip AnimJump;
    public AnimationClip AnimFall;
    public AnimationClip AnimLand;

    [Header("Animation Time")]
    public float TimeDraw;
    public float TimeReloadPart;
    public float TimeReloadFull;

    [HideInInspector] public int CurrentRounds;
    [HideInInspector] public int CurrentReserve;
    [HideInInspector] public bool CanShoot = true;
}