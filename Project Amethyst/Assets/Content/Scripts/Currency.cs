using TMPro;
using UnityEngine;

public sealed class Currency
{
    private TextMeshProUGUI _counter;

    private int _amount;

    public int Amount
    {
        get { return _amount; }
    }

    public Currency(TextMeshProUGUI counter)
    {
        _counter = counter;
    }

    public void Add(int value)
    {
        _amount += value;
        UpdateCounter();
    }

    public void Remove(int value)
    {
        _amount -= value;
        UpdateCounter();
    }

    public void UpdateCounter()
    {
        _counter.text = $"{_amount}";
    }
}