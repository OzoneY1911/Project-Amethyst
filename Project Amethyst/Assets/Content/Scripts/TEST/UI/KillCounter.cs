using TMPro;
using UnityEngine;

public class KillCounter : SingletonMono<KillCounter>
{
    [SerializeField] private TextMeshProUGUI _counterText;

    private int _counter;
    public int Counter { get => _counter; private set => _counter = value; }

    public void UpdateCounter()
    {
        _counter++;
        _counterText.text = $"Enemies Defeated: {_counter}";
    }
}