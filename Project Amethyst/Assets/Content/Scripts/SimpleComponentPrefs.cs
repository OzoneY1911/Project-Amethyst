using UnityEngine;
using UnityEngine.UI;

public abstract class SimpleComponentPrefs : ComponentPrefs
{
    [SerializeField] private string _value;
    [SerializeField] private Component _component;

    private void Awake()
    {
        Listen(_component);
    }

    private void Listen(Component component)
    {
        dynamic value = null;

        CheckType(_value, ref value);

        if (component is Button)
        {
            GetComponent<Button>().onClick.AddListener(delegate { PlayerSettings.SetPrefs(_key, value); });
        }
        else if (component is Toggle)
        {
            GetComponent<Toggle>().onValueChanged.AddListener(delegate { PlayerSettings.SetPrefs(_key, value); });
        }
    }
}