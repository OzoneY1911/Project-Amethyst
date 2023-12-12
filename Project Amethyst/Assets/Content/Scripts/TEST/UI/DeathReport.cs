using TMPro;
using UnityEngine;

public class DeathReport : SingletonMono<DeathReport>
{
    [SerializeField] private TextMeshProUGUI _killCounterTMP;
    [SerializeField] private TextMeshProUGUI _timeCounterTMP;

    public void UpdateReport()
    {
        _killCounterTMP.text = $"Enemies Defeated: {KillCounter.Instance.Counter}";
        _timeCounterTMP.text = $"Time survived: {(int) Time.time / 60} minutes";
    }
}