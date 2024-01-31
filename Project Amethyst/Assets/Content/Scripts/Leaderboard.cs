using System.Collections;
using UnityEngine.Networking;

public class Leaderboard : SingletonMono<Leaderboard>
{
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
        using (UnityWebRequest www = UnityWebRequest.Post("http://dreamlo.com/lb/GPcLVSiD-UGUy6mSXZ8Rvgkd3VADXNM0yh4vhSYaoeKg/add", "{ \"field1\": 1, \"field2\": 2 }", "application/json"))
        {
            yield return www.SendWebRequest();

        }
    }
}