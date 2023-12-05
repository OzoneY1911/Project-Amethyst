using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : SingletonMono<LevelLoader>
{
    [SerializeField] private GameObject _loadScreen;
    [SerializeField] private Slider _loadSlider;
    [SerializeField] private TextMeshProUGUI _loadText;

    public void LoadLevel(string name)
    {
        StartCoroutine(LoadLevelAsync(name));
    }

    private IEnumerator LoadLevelAsync(string name)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);

        _loadScreen.SetActive(true);

        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            _loadSlider.value = operation.progress / 0.9f;
            _loadText.text = (int) (100f / 0.9f * operation.progress) + "%";

            if (operation.progress >= 0.9f)
            {
                _loadText.text = "Press SPACE to continue";

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    operation.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }
}