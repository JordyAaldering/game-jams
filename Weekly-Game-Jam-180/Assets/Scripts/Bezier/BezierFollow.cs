using System.Collections;
using UnityEngine;

public class BezierFollow : MonoBehaviour
{
	[SerializeField] private float moveSpeedMin;
	[SerializeField] private float moveSpeedMax;
	[SerializeField] private float randomOffset;

	public Transform[] routes;

	private float moveSpeed;
	private Vector2 offset;

	private void Awake()
	{
		moveSpeed = Random.Range(moveSpeedMin, moveSpeedMax);

		float x = Random.Range(-randomOffset, randomOffset);
		float y = Random.Range(-randomOffset, randomOffset);
		offset = new Vector2(x, y);
	}

	public IEnumerator FollowRoute()
	{
		float t = Random.Range(0f, 1f);
		int currentRoute = Random.Range(0, routes.Length);

		while (true) {
			Vector2 p0 = routes[currentRoute].GetChild(0).position;
			Vector2 p1 = routes[currentRoute].GetChild(1).position;
			Vector2 p2 = routes[currentRoute].GetChild(2).position;
			Vector2 p3 = routes[currentRoute].GetChild(3).position;

			while (t < 1) {
				t += moveSpeed * Time.deltaTime;

				Vector2 pos = Mathf.Pow(1 - t, 3) * p0 +
					3 * Mathf.Pow(1 - t, 2) * t * p1 +
					3 * (1 - t) * Mathf.Pow(t, 2) * p2 +
					Mathf.Pow(t, 3) * p3;

				transform.position = pos + offset;
				yield return null;
			}

			t = 0f;
			currentRoute = (currentRoute + 1) % routes.Length;
		}
	}
}
