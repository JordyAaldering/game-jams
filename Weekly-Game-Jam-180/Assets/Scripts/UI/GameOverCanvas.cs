using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCanvas : MonoBehaviour
{
	[SerializeField] private GameObject gameOverPanel;

	private void Awake()
	{
		gameOverPanel.SetActive(false);
	}

	public void EnablePanel()
	{
		gameOverPanel.SetActive(true);
		ScoreManager.DisablePanel();
		UpgradeTimerPanel.DisablePanel();
	}

	public void LoadScene(int scene)
	{
		SceneManager.LoadScene(scene);
	}
}
