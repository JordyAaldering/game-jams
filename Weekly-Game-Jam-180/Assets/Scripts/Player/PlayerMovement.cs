using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
	[SerializeField] private float dashSpeed;
	[SerializeField] private float dashTime;

	[Header("GFX")]
	[SerializeField] private SpriteRenderer shipSprite;
	[SerializeField] private GameObject shieldSprite;
	[SerializeField] private Color shipDashColor;

	public static bool IsDashing { get; private set; }

	// Upgrades
	public static bool CanDash { get; set; } = true;
	public static bool AlwaysDash { get; set; } = false;
	public static bool InvertControls { get; set; } = false;
	public static float MoveSpeedModifier { get; set; } = 1f;

	private Vector2 moveDir;
	private Vector2 dashDir = Vector2.up;
    private Rigidbody2D rb;

	private void Awake()
	{
		shieldSprite.SetActive(false);

		IsDashing = false;

		CanDash = true;
		AlwaysDash = false;
		InvertControls = false;
		MoveSpeedModifier = 1f;

		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		moveDir = new Vector2(
			Input.GetAxis("Horizontal"),
			Input.GetAxis("Vertical")
		);

		if (moveDir.magnitude > 0.5f) {
			dashDir = moveDir;
		}

		// clamp diagonal movement speed
		moveDir = Vector2.ClampMagnitude(moveDir, 1f);

		if (CanDash && !IsDashing && (Input.GetButtonDown("Dash") || AlwaysDash)) {
			StartCoroutine(Dash(dashDir));
		}
	}

	private void FixedUpdate()
	{
		if (!IsDashing) {
			rb.velocity = moveSpeed * MoveSpeedModifier * moveDir;
			if (InvertControls) {
				rb.velocity = -rb.velocity;
			}
		}
	}

	private IEnumerator Dash(Vector2 dashDir)
	{
		IsDashing = true;

		Color oldColor = shipSprite.color;
		shipSprite.color = shipDashColor;
		shieldSprite.SetActive(true);

		for (float t = 0; t < dashTime; t += Time.deltaTime) {
			rb.velocity = dashSpeed * dashDir;
			if (InvertControls) {
				rb.velocity = -rb.velocity;
			}

			yield return null;
		}

		shipSprite.color = oldColor;
		shieldSprite.SetActive(false);

		IsDashing = false;
	}
}
