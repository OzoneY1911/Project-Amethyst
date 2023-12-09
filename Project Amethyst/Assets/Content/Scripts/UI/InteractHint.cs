using TMPro;
using UnityEngine;

public class InteractHint : SingletonMono<InteractHint>
{
    [SerializeField] private TextMeshProUGUI _hintText;
    public string HintText
    {
        get
        {
            return _hintText.text;
        }
        set
        {
            _hintText.text = value;
        }
    }
}