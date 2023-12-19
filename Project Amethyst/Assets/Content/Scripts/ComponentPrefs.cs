using UnityEngine;

public abstract class ComponentPrefs : MonoBehaviour
{
    protected enum ValueType
    {
        Integer,
        Floating,
        Text,
        Boolean
    }

    [SerializeField] protected ValueType _valueType;
    [SerializeField] protected string _key;

    protected void CheckType(in string inputValue, ref dynamic outputValue)
    {
        switch (_valueType)
        {
            case ValueType.Integer:
                outputValue = int.Parse(inputValue);
                break;
            case ValueType.Floating:
                outputValue = float.Parse(inputValue);
                break;
            case ValueType.Text:
                outputValue = inputValue;
                break;
        }
    }
}