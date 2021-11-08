using UnityEngine;

public class RotateAroundPlayer : StateMachineBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float orbitDistanceMin;
    [SerializeField] private float orbitDistanceMax;
    [SerializeField] private float orbitRotateSpeedMin;
    [SerializeField] private float orbitRotateSpeedMax;

    [Header("State Transition")]
    [SerializeField] private float minStateTime;
    [SerializeField] private float maxStateTime;

    private float orbitDistance;
    private float orbitRotateSpeed;
    private float stateTimeLeft;

    private Transform player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        orbitDistance = Random.Range(orbitDistanceMin, orbitDistanceMax);
        orbitRotateSpeed = Random.Range(orbitDistanceMin, orbitDistanceMax);
        if (Random.Range(0f, 1f) > 0.5f) {
            orbitRotateSpeed = -orbitRotateSpeed;
        }

        stateTimeLeft = Random.Range(minStateTime, maxStateTime);

        player = GameObject.FindWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!player) {
            return;
		}

        Transform transform = animator.transform;
        Vector3 angle = LerpByDistance(player.position, transform.position, orbitDistance);
        Vector3 target = RotatePointAroundPivot(angle, player.position);
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        stateTimeLeft -= Time.deltaTime;
        if (stateTimeLeft <= 0f) {
            if (Random.Range(0f, 1f) > 0.2f) {
                animator.Play("MoveTowardsPlayer");
			} else {
                animator.Play("Idle");
			}
		}
    }

    private static Vector3 LerpByDistance(Vector3 from, Vector3 to, float dist)
    {
        return dist * (to - from).normalized + from;
    }

    private Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot)
    {
        return Quaternion.Euler(0f, 0f, orbitRotateSpeed) * (point - pivot) + pivot;
    }
}
