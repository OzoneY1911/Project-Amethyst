using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PSPGame : SingletonMono<PSPGame>
{
    private static InputManager _inputManager => InputManager.Instance;

    [SerializeField] private Slider[] _health;
    [SerializeField] private Sprite[] _veggieList;
    [SerializeField] private Image _currentVeggie;

    protected override void Awake()
    {
        base.Awake();

        UpdateVeggie();
    }

    private void Update()
    {
        if (PSP.PspOn)
        {
            foreach (Slider slider in _health)
            {
                slider.value -= 0.05f * Time.deltaTime;
            }

            if (_inputManager.GetUILeft())
            {
                if (_currentVeggie.sprite == _veggieList[0] || _currentVeggie.sprite == _veggieList[5])
                {
                    Heal(0);
                }
                else
                {
                    Damage(0);
                }
                UpdateVeggie();
            }
            else if (_inputManager.GetUIUp())
            {
                if (_currentVeggie.sprite == _veggieList[0] || _currentVeggie.sprite == _veggieList[1] || _currentVeggie.sprite == _veggieList[4] || _currentVeggie.sprite == _veggieList[5])
                {
                    Heal(1);
                }
                else
                {
                    Damage(1);
                }
                UpdateVeggie();
            }
            else if (_inputManager.GetUIRight())
            {
                Heal(2);
                UpdateVeggie();
            }
        }
    }

    private void UpdateVeggie()
    {
        _currentVeggie.sprite = _veggieList[Random.Range(0, _veggieList.Length)];
    }

    private void Heal(int index)
    {
        _health[index].value += 0.2f;
    }

    private void Damage(int index)
    {
        _health[index].value -= 0.1f;
    }
}