using Common;
using Score.Events;
using UnityEngine;

namespace Score
{
    public class ScoreManager : MonoBehaviour, IService
    {
        public int Score { get; private set; }
        public int HighScore { get; private set; }

        public event ScoreChangedEvent ScoreChanged;
        public event HighScoreChangedEvent HighScoreChanged;

        public void AddScore(int score)
        {
            ScoreChanged?.Invoke(Score, Score += score);

            if (Score > HighScore)
            {
                HighScoreChanged?.Invoke(HighScore = Score);
            }
        }

        public void ResetScore()
        {
            ScoreChanged?.Invoke(Score, Score = 0);
        }
    }
}
