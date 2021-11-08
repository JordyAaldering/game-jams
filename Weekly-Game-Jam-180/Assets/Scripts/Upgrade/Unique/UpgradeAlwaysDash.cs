using UnityEngine;

[CreateAssetMenu(fileName = "Always Dash", menuName = "Upgrade/Always Dash")]
public class UpgradeAlwaysDash : UpgradeBase
{
	[SerializeField] private float scorePerSecImprovement;

	protected override void ApplyUpgrade()
	{
		PlayerMovement.AlwaysDash = true;
		ScoreManager.Instance.ScorePerSecond += scorePerSecImprovement;
	}
}
