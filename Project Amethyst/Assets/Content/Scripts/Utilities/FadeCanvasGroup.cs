using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class FadeCanvasGroup : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    [SerializeField] private float _fadeSpeed = 0.1f;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void ShowCanvas()
    {
        StartCoroutine(FadeIn());
    }

    public void HideCanvas()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeIn()
    {
        while (_canvasGroup.alpha != 1f)
        {
            _canvasGroup.alpha += _fadeSpeed;
            yield return null;
        }
    }
    private IEnumerator FadeOut()
    {
        while (_canvasGroup.alpha != 0f)
        {
            _canvasGroup.alpha -= _fadeSpeed;
            yield return null;
        }
    }
}