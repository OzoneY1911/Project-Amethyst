using System.Collections;
using UnityEngine.Networking;
using UnityEngine;
using TMPro;

public class Leaderboard : SingletonMono<Leaderboard>
{
    [SerializeField] private TMP_InputField _input;

    protected override void Awake()
    {
        base.Awake();

    }

    public void Submit()
    {
        StartCoroutine(Upload());
    }

    private IEnumerator Upload()
    {
        using (UnityWebRequest www = UnityWebRequest.Get($"http://dreamlo.com/lb/GPcLVSiD-UGUy6mSXZ8Rvgkd3VADXNM0yh4vhSYaoeKg/add/{_input.text}/{KillCounter.Instance.Counter.ToString()}"))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}