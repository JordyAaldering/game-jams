using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
	[SerializeField] private float initialUpgradeTimer;
	[SerializeField] private float upgradeInterval;
	[SerializeField] private List<UpgradeBase> uniqueUpgrades;
    [SerializeField] private List<UpgradeBase> repeatableUpgrades;

	[Header("UI")]
	[SerializeField] private GameObject upgradeGroup;
    [SerializeField] private UpgradePanel[] upgradePanels;

	public static float TimeUntilUpgrade { get; private set; }
	public static bool AcceptClicks { get; private set; }

	private void Awake()
	{
		// Set default laser upgrade values
		Laser.PlayerSpeedModifier = 1f;
		Laser.EnemySpeedModifier = 1f;

		TimeUntilUpgrade = initialUpgradeTimer;
		AcceptClicks = false;

		upgradeGroup.SetActive(false);
	}

	private void Update()
	{
		if (PlayerCombat.IsDead) {
			return;
		}

		TimeUntilUpgrade -= Time.deltaTime;

		if (TimeUntilUpgrade <= 0f) {
			OpenUpgradePanel();
			StartCoroutine(EnableClickingAfter(0.05f));
		}
	}

	private void OpenUpgradePanel()
	{
		Time.timeScale = 0.05f;
		TimeUntilUpgrade = upgradeInterval;
		upgradeGroup.SetActive(true);

		SetUpgrades();
	}

	private System.Collections.IEnumerator EnableClickingAfter(float time)
	{
		AcceptClicks = false;
		yield return new WaitForSeconds(time);
		AcceptClicks = true;
	}

	public void CloseUpgradePanel()
	{
		Time.timeScale = 1f;
		upgradeGroup.SetActive(false);
	}

	private void SetUpgrades()
	{
		if (uniqueUpgrades.Count > 0) {
			// always give one unique upgrade
			SetUniqueUpgrade();
			SetRemainingUpgrades(1);
		} else {
			// No unique upgrades remain
			SetRemainingUpgrades(0);
		}
	}

	private void SetUniqueUpgrade()
	{
		int index = Random.Range(0, uniqueUpgrades.Count);
		UpgradeBase upgrade = uniqueUpgrades[index];
		uniqueUpgrades.RemoveAt(index);
		upgradePanels[0].SetUpgrade(upgrade);
	}

	private void SetRemainingUpgrades(int startIndex)
	{
		var upgrades = repeatableUpgrades
			.OrderBy(x => Random.Range(0f, 1f))
			.Take(upgradePanels.Length - startIndex);

		foreach (var upgrade in upgrades) {
			upgradePanels[startIndex].SetUpgrade(upgrade);
			startIndex++;
		}
	}
}
