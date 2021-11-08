using UnityEngine;

[CreateAssetMenu(fileName = "Laser Speed", menuName = "Upgrade/Laser Speed")]
public class UpgradeLaserSpeed : UpgradeBase
{
	[SerializeField] private bool isPlayerSpeed;
	[SerializeField] private float laserSpeedModifier;
	[SerializeField] private float scoreIncrease;

	protected override void ApplyUpgrade()
	{
		if (isPlayerSpeed) {
			Laser.PlayerSpeedModifier *= laserSpeedModifier;
		} else {
			Laser.EnemySpeedModifier *= laserSpeedModifier;
		}

		ScoreManager.Instance.Score += scoreIncrease;
	}
}
