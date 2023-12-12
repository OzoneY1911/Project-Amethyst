using TMPro;
using UnityEngine;

public class PlayerCurrency : SingletonMono<PlayerCurrency>
{
    private Currency _cash;
    private Currency _ruby;
    private Currency _emerald;
    private Currency _sapphire;

    public Currency Cash {  get { return _cash; } }
    public Currency Ruby { get { return _ruby; } }
    public Currency Emerald { get { return _emerald; } }
    public Currency Sapphire { get { return _sapphire; } }

    public Currency[] CurrencyList;

    [SerializeField] private TextMeshProUGUI _cashCounter;
    [SerializeField] private TextMeshProUGUI _rubyCounter;
    [SerializeField] private TextMeshProUGUI _emeraldCounter;
    [SerializeField] private TextMeshProUGUI _sapphireCounter;

    protected override void Awake()
    {
        base.Awake();
        
        InitCurrency();
    }

    private void Start()
    {
        _cash.UpdateCounter();
        _ruby.UpdateCounter();
        _emerald.UpdateCounter();
        _sapphire.UpdateCounter();

        CurrencyList = new Currency[] { _ruby, _emerald, _sapphire };

        Add(_cash, 100);
        Add(_ruby, 100);
        Add(_emerald, 100);
        Add(_sapphire, 100);
    }

    private void InitCurrency()
    {
        _cash = new Currency(_cashCounter);
        _ruby = new Currency(_rubyCounter);
        _emerald = new Currency(_emeraldCounter);
        _sapphire = new Currency(_sapphireCounter);
    }

    private void OnDestroy()
    {
        _cash = null;
        _ruby = null;
        _emerald = null;
        _sapphire = null;
    }

    public void Add(Currency currency, int value)
    {
        currency.Add(value);
    }
}