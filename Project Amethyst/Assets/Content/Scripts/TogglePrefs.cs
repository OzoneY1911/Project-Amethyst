using UnityEngine;
using System.Collections.Generic;

public class TogglePrefs : ComponentPrefs
{
    [SerializeField] private string[] _valueList = new string[2];

    public void Listen(bool toggle)
    {
        dynamic valueList = new List<dynamic>(2);

        for (int i = 0; i < _valueList.Length; i++)
        {
            valueList.Add(_valueList[i]);
            CheckType(_valueList[i], ref valueList[i]);
        }

        switch (toggle)
        {
            case false:
                PlayerSettings.SetPrefs(_key, valueList[0]);
                break;
            case true:
                PlayerSettings.SetPrefs(_key, valueList[1]);
                break;
        }

        /*if (!toggle)
        {
            PlayerSettings.SetPrefs(_key, valueList[0]);
        }
        else
        {
            PlayerSettings.SetPrefs(_key, valueList[1]);
        }*/
    }
}