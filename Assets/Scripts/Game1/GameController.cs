using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace Game1
{
    public class GameController : MonoBehaviour
    {
        private static GameController instance;

        public static GameController Instance { get { return instance; } }

        private int score;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private string sceneName;

        private void Awake()
        {
            instance = this;
        }

        public void UpdateScore(int value)
        {
            score += value;
            scoreText.text = $"Score: {score}";
        }

        public void GameOver()
        {
            GameData.score = score;
            SceneManager.LoadScene(sceneName);
        }
    }

}
