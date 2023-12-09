public class RubyShop : ShopController
{
    private void Start()
    {
        _playerShopCurrency = _playerCurrency.Ruby;
    }

    public void BuyEmeraldSkill(RubySkillChoice choice)
    {
        int price = (int)choice.SkillName;

        if (CheckPrice(price))
        {
            switch (choice.SkillName)
            {
                case RubySkill.DamageBoost:
                    _playerShopCurrency.Remove(price);
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