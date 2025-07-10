using UnityEngine;

public class Highscore : MonoBehaviour
{
    [System.Serializable]
    public struct PlayerScore
    {
        public string Name;
        public int Score;

        public PlayerScore(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }

    [System.Serializable]
    private class PlayerScoreList
    {
        public PlayerScore[] scores;

        public PlayerScoreList(PlayerScore[] scores)
        {
            this.scores = scores;
        }
    }

    public static void Save(string name, int score)
    {
        // Load existing scores
        PlayerScore[] existingScores = Load();

        // Create a new list with the new score added
        PlayerScore[] updatedScores = new PlayerScore[existingScores.Length + 1];
        existingScores.CopyTo(updatedScores, 0);
        updatedScores[existingScores.Length] = new PlayerScore(name, score);

        // Serialize and save
        PlayerScoreList scoreList = new PlayerScoreList(updatedScores);
        string json = JsonUtility.ToJson(scoreList);
        PlayerPrefs.SetString("playerScores", json);
        PlayerPrefs.Save();
    }

    public static PlayerScore[] Load()
    {
        string json = PlayerPrefs.GetString("playerScores", "");

        if (string.IsNullOrEmpty(json))
        {
            return new PlayerScore[0]; // Return empty array if no data
        }

        PlayerScoreList scoreList = JsonUtility.FromJson<PlayerScoreList>(json);
        return scoreList?.scores ?? new PlayerScore[0];
    }
}
