using System.Collections;
using UnityEngine.Networking;
using UnityEngine;
using TMPro;

public class Leaderboard : SingletonMono<Leaderboard>
{
    [SerializeField] private TMP_InputField _input;

    [SerializeField] private GameObject _row;
    [SerializeField] private Transform _column;

    protected override void Awake()
    {
        base.Awake();
    }

    public void UpdateBoard()
    {
        StartCoroutine(Download());
    }

    private IEnumerator Download()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://dreamlo.com/lb/65b9f2818f40bbbdf0f470e2/json"))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Download complete!");

                HighScore highScore = HighScore.CreateFromJSON(www.downloadHandler.text);

                while (_column.transform.childCount != 0)
                {
                    Destroy(_column.transform.GetChild(0));
                }

                foreach (HighScoreEntry entry in highScore.dreamlo.leaderboard.entry)
                {
                    GameObject row = Instantiate(_row, _column);
                    row.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = entry.name;
                    row.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = entry.score;
                }
            }
        }
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
                Debug.Log("Upload complete!");
            }
        }
    }
}