using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField] private float spawnDistance;
	[SerializeField] private float spawnTimeMin;
	[SerializeField] private float spawnTimeMax;

	[SerializeField] private EnemyCombat enemyPrefab;

	// Upgrades
	public static float SpawnTimeModifier { get; set; } = 1f;

	private float spawnTimeLeft = 1f;
	private int count = 0;

	private void Awake()
	{
		SpawnTimeModifier = 1f;
	}

	private void Update()
	{
		if (PlayerCombat.IsDead) {
			return;
		}

		spawnTimeLeft -= Time.deltaTime;

		if (spawnTimeLeft <= 0f) {
			spawnTimeLeft = Random.Range(spawnTimeMin, spawnTimeMax) * SpawnTimeModifier;

			float x = Random.Range(0f, 2f * spawnDistance);
			float y = Mathf.Cos(Mathf.PI / spawnDistance * x);
			Vector3 pos = new Vector3(x - spawnDistance, y * spawnDistance);

			var enemy = Instantiate(enemyPrefab, pos, Quaternion.identity, transform);

			string name = enemy.name = $"Enemy ({++count})";
			Debug.Log($"{name} spawned at ({pos.x}, {pos.y})");
		}
	}
}
