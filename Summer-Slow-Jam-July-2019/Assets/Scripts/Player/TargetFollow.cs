#pragma warning disable 0649
using UnityEngine;

namespace Player
{
	public class TargetFollow : MonoBehaviour
	{
		[SerializeField] private Transform targetToFollow;

		[SerializeField] private float dampTime = 0.15f;
		[SerializeField] private float xOffset = 5f;
		[SerializeField] private float yOffset = 5f;

		private Vector3 velocity = Vector3.zero;

		public void FixedUpdate()
		{
			Vector3 pos = transform.position;
			Vector3 destination = targetToFollow.position;

			destination.x -= xOffset;
			destination.y += yOffset;
			transform.position = Vector3.SmoothDamp(pos, destination, ref velocity, dampTime);
		}
	}
}
