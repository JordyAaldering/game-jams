using UnityEngine;

[CreateAssetMenu(fileName = "Move Slower", menuName = "Upgrade/Move Slower")]
public class UpgradeMoveSlower : UpgradeBase
{
	[SerializeField] private float moveSpeedModifier;
	[SerializeField] private float scoreIncrease;

	protected override void ApplyUpgrade()
	{
		PlayerMovement.MoveSpeedModifier = moveSpeedModifier;
		ScoreManager.Instance.Score += scoreIncrease;
	}
}
