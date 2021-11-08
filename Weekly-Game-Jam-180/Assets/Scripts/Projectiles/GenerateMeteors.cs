using UnityEngine;

public class GenerateMeteors : MonoBehaviour
{
	[SerializeField] private int meteorAmount;
	[SerializeField] private BezierFollow meteorPrefab;
	[SerializeField] private Transform[] routes;

	private void Awake()
	{
		for (int i = 0; i < meteorAmount; i++) {
			BezierFollow meteor = Instantiate(meteorPrefab, transform);
			meteor.name = $"Meteor ({i + 1})";
			meteor.routes = routes;
			meteor.GetComponent<SpriteRenderer>().sortingOrder = i;
			StartCoroutine(meteor.FollowRoute());
		}
	}
}
