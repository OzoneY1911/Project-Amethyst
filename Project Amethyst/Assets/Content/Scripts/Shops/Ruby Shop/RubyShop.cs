public class RubyShop : ShopController
{
    private static WeaponController _weaponController => WeaponController.Instance;
    private static WeaponSelector _weaponSelector => WeaponSelector.Instance;
    private static WeaponSO _currentWeapon => WeaponSelector.Instance.CurrentWeapon;

    private void Start()
    {
        _playerShopCurrency = _playerCurrency.Ruby;
    }

    public void BuyRubySkill(RubySkillChoice choice)
    {
        int price = (int)choice.SkillName;

        if (CheckPrice(price))
        {
            _playerShopCurrency.Remove(price);
            switch (choice.SkillName)
            {
                case RubySkill.DamageBoost:
                    _weaponController.DamageMultiplier *= 2;
                    _buttonList[0].interactable = false;
                    break;
                case RubySkill.RestoreAmmo:
                    _currentWeapon.CurrentReserve = _currentWeapon.MaxReserve;
                    break;
                case RubySkill.DoubleBarrel:
                    _weaponSelector.CurrentShotgun = _weaponSelector.ShotgunList[0];
                    _weaponSelector.Equip(_weaponSelector.CurrentShotgun, _weaponSelector.ShotgunHolder, out _weaponSelector.ShotgunObject);
                    _buttonList[1].interactable = false;
                    break;
                case RubySkill.M4A1:
                    _weaponSelector.CurrentRifle = _weaponSelector.RifleList[0];
                    _weaponSelector.Equip(_weaponSelector.CurrentRifle, _weaponSelector.RifleHolder, out _weaponSelector.RifleObject);
                    _buttonList[2].interactable = false;
                    break;
            }
        }
        else
        {
            if (_showingFail)
            {
                StopCoroutine(_failCoroutine);
            }
            _failCoroutine = StartCoroutine(FailPurchase());
        }
    }
}