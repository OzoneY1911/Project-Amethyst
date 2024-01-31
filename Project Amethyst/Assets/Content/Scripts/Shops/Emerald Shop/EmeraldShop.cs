public class EmeraldShop : ShopController
{
    private static MovementController _movementController => MovementController.Instance;
    private static WeaponController _weaponController => WeaponController.Instance;

    private void Start()
    {
        _playerShopCurrency = _playerCurrency.Emerald;
    }

    public void BuyEmeraldSkill(EmeraldSkillChoice choice)
    {
        int price = (int)choice.SkillName;

        if (CheckPrice(price))
        {
            switch (choice.SkillName)
            {
                case EmeraldSkill.MovementSpeed:
                    _playerShopCurrency.Remove(price);
                    _movementController.MovementModifier *= 1.5f;
                    _buttonList[0].interactable = false;
                    break;
                case EmeraldSkill.ReloadSpeed:
                    _playerShopCurrency.Remove(price);
                    _weaponController.ReloadMultiplier *= 1.5f;
                    _buttonList[1].interactable = false;
                    break;
                case EmeraldSkill.DrawHolsterSpeed:
                    _playerShopCurrency.Remove(price);
                    _weaponController.DrawHolsterMultiplier *= 2f;
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