using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class MeteorRandomizer : MonoBehaviour
{
    [SerializeField] private float rotateSpeedMin;
    [SerializeField] private float rotateSpeedMax;
	private float rotateSpeed;

	[SerializeField] private float scaleMin;
	[SerializeField] private float scaleMax;

	[SerializeField] private Sprite[] sprites;

	private void Awake()
	{
		rotateSpeed = Random.Range(rotateSpeedMin, rotateSpeedMax);

		float scale = Random.Range(scaleMin, scaleMax);
		transform.localScale = new Vector3(scale, scale, 1f);

		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		int spriteIndex = Random.Range(0, sprites.Length);
		sr.sprite = sprites[spriteIndex];

		// Add collider via code to automatically generate points
		gameObject.AddComponent<PolygonCollider2D>();
	}

	private void Update()
	{
		transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
	}
}
