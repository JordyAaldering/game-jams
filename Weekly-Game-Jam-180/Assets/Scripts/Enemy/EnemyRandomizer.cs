using UnityEngine;

public class EnemyRandomizer : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

	private void Awake()
	{
		SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
		int spriteIndex = Random.Range(0, sprites.Length);
		sr.sprite = sprites[spriteIndex];

		Animator anim = GetComponent<Animator>();
		anim.Play(Random.Range(0f, 1f) > 0.5f
			? "MoveTowardsPlayer" : "RotateAroundPlayer");
	}
}
