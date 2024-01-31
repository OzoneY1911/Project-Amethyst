public class RubyShop : ShopController
{
    private static WeaponController _weaponController => WeaponController.Instance;
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
            switch (choice.SkillName)
            {
                case RubySkill.DamageBoost:
                    _playerShopCurrency.Remove(price);
                    _weaponController.DamageMultiplier *= 2;
                    _buttonList[0].interactable = false;
                    break;
                case RubySkill.RestoreAmmo:
                    _playerShopCurrency.Remove(price);
                    _currentWeapon.CurrentReserve = _currentWeapon.MaxReserve;
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