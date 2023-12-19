using UnityEngine;
using UnityEngine.UI;

public class SimpleComponentPrefs : ComponentPrefs
{
    [SerializeField] private string _value;

    private void Awake()
    {
        Listen();
    }

    private void Listen()
    {
        dynamic value = null;

        CheckType(_value, ref value);

        GetComponent<Button>().onClick.AddListener(delegate { PlayerSettings.SetPrefs(_key, value); });
    }
}