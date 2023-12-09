using UnityEngine;
using static UnityEngine.Rendering.HDROutputUtils;

public class MainMenuController : MenuController
{
    protected override void Awake()
    {
        base.Awake();

        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }
    }
}