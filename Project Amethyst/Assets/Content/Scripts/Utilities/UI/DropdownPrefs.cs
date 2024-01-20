using UnityEngine;

public class DropdownPrefs : ComponentPrefs
{
    [SerializeField] private string[] _valueList;

    public void Listen(int index)
    {
        dynamic value = null;

        CheckType(_valueList[index], ref value);

        PlayerSettings.SetPrefs(_key, value);
    }
}