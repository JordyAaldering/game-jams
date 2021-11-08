using UnityEngine;

[CreateAssetMenu(fileName = "Faster Enemy Spawning", menuName = "Upgrade/Faster Enemy Spawning")]
public class FasterEnemySpawning : UpgradeBase
{
	[SerializeField] private float spawnTimeModifier;
	[SerializeField] private float scoreIncrease;

	protected override void ApplyUpgrade()
	{
		EnemySpawning.SpawnTimeModifier = spawnTimeModifier;
		ScoreManager.Instance.Score += scoreIncrease;
	}
}
