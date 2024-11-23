using Common;
using TMPro;
using UnityEngine;

namespace Score.UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI highScoreText;
        
        private void OnEnable()
        {
            Services.ScoreManager.ScoreChanged += OnScoreChanged;
            Services.ScoreManager.HighScoreChanged += OnHighScoreChanged;
        }

        private void OnDisable()
        {
            Services.ScoreManager.ScoreChanged -= OnScoreChanged;
            Services.ScoreManager.HighScoreChanged -= OnHighScoreChanged;
        }

        private void Start()
        {
            SetScoreText(0);
            // get from score manager
            SetHighScoreText(0);
        }

        private void SetScoreText(int newScore)
        {
            scoreText.text = $"Score: {newScore}";
        }

        private void SetHighScoreText(int highScore)
        {
            highScoreText.text = $"High Score: {highScore}";
        }

        private void OnScoreChanged(int lastScore, int newScore)
        {
            SetScoreText(newScore);
        }

        private void OnHighScoreChanged(int highScore)
        {
            SetHighScoreText(highScore);
        }
    }
}