using UnityEngine;

public class LookTowardsPlayer : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;

    private Transform player;

	private void Awake()
	{
        player = GameObject.FindWithTag("Player").transform;
	}

	void Update()
    {
        if (!player) {
            return;
        }

        Vector3 lookPos = player.position - transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, rotateSpeed * Time.deltaTime);
    }
}
