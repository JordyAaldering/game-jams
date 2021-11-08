using TMPro;
using UnityEngine;

public class UpgradeTimerPanel : MonoBehaviour
{
	[SerializeField] private GameObject timerPanel;
    [SerializeField] private TextMeshProUGUI timeUntilUpgrade;

	private void Update()
	{
		if (!PlayerCombat.IsDead) {
			timeUntilUpgrade.text = UpgradeManager.TimeUntilUpgrade.ToString("0.0");
		}
	}


	public static void DisablePanel()
	{
		FindObjectOfType<UpgradeTimerPanel>().timerPanel.SetActive(false);
	}

}
