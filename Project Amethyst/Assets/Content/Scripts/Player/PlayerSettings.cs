using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public static class PlayerSettings
{
    public static void SetPrefs(string key, dynamic value)
    {
        switch (value)
        {
            case int:
                PlayerPrefs.SetInt(key, value);
                break;
            case float:
                PlayerPrefs.SetFloat(key, value);
                break;
            case string:
                PlayerPrefs.SetString(key, value);
                break;
        }
        PlayerPrefs.Save();
        LoadSettings();
    }

    public static void LoadSettings()
    {
        // Locate the current URP Asset
        UniversalRenderPipelineAsset data = GraphicsSettings.currentRenderPipeline as UniversalRenderPipelineAsset;

        // Do nothing if Unity can't locate the URP Asset
        if (!data) return;

        data.msaaSampleCount = PlayerPrefs.GetInt("MSAA");
    }
}