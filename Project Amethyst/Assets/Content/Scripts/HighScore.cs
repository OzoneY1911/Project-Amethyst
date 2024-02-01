using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighScore
{
    public HighScoreDreamlo dreamlo;

    public static HighScore CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<HighScore>(jsonString);
    }
}

[System.Serializable]
public class HighScoreDreamlo
{
    public HighScoreLeaderboard leaderboard;
}

[System.Serializable]
public class HighScoreLeaderboard
{
    public List<HighScoreEntry> entry;
}

[System.Serializable]
public class HighScoreEntry
{
    public string name;
    public string score;
    public string seconds;
    public string text;
    public string date;
}