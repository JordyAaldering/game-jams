using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerCombat : MonoBehaviour
{
	[SerializeField] private float fireCooldown;
	[SerializeField] private Laser laserPrefab;

	[SerializeField] private GameObject dieExplosion;

	public static bool IsDead { get; private set; }

	// Upgrades
	public static bool CanShoot { get; set; } = true;

	private float fireCooldownLeft;

	private void Awake()
	{
		IsDead = false;
		CanShoot = true;
	}

	private void Update()
	{
		if (CanShoot && Input.GetButtonDown("Fire1") && fireCooldownLeft <= 0f) {
			fireCooldownLeft = fireCooldown;

			Laser laser = Instantiate(laserPrefab, transform.position, transform.rotation);
			laser.Parent = gameObject;
			laser.ParentIsPlayer = true;
		}

		if (fireCooldownLeft > 0f) {
			fireCooldownLeft -= Time.deltaTime;
		}
	}

	public void Die(bool force = false)
	{
		if (!force && PlayerMovement.IsDashing) {
			return;
		}

		IsDead = true;

		int curHigh = PlayerPrefs.GetInt("highScore", 0);
		int high = Mathf.Max(curHigh, (int)ScoreManager.Instance.Score);
		PlayerPrefs.SetInt("highScore", high);

		Instantiate(dieExplosion, transform.position, transform.rotation);

		FindObjectOfType<UpgradeManager>().CloseUpgradePanel();
		FindObjectOfType<GameOverCanvas>().EnablePanel();
		Destroy(gameObject);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Meteor")) {
			Die(true);
		}
	}
}
