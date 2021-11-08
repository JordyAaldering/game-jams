#pragma warning disable 0649
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class GameMenu : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private GameObject levelCompletePanel;

        private void Start()
        {
            Time.timeScale = 1f;
        }

        public void GameOver()
        {
            Time.timeScale = 0f;
            gameOverPanel.SetActive(true);
        }

        public void Restart()
        {
            SceneManager.LoadScene(1);
        }

        public void LevelComplete()
        {
            Time.timeScale = 0f;
            levelCompletePanel.SetActive(true);
        }

        public void Menu()
        {
            SceneManager.LoadScene(0);
        }
    }
}
