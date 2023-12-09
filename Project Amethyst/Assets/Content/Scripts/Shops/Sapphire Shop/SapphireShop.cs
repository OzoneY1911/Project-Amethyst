public class SapphireShop : ShopController
{
    private static PlayerHealth _playerHealth => PlayerHealth.Instance;

    private void Start()
    {
        _playerShopCurrency = _playerCurrency.Sapphire;
    }

    public void BuySapphireSkill(SapphireSkillChoice choice)
    {
        int price = (int)choice.SkillName;

        if (CheckPrice(price))
        {
            switch (choice.SkillName)
            {
                case SapphireSkill.MaxHealth:
                    _playerShopCurrency.Remove(price);
                    _playerHealth.MaxHealth *= 2;
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