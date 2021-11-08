using UnityEngine;

public class MoveTowardsPlayer : StateMachineBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float stoppingDistanceMin;
    [SerializeField] private float stoppingDistanceMax;

    [Header("State Transition")]
    [SerializeField] private float minStateTime;
    [SerializeField] private float maxStateTime;

    private float stoppingDistance;
    private float stateTimeLeft;

    private Transform player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stoppingDistance = Random.Range(stoppingDistanceMin, stoppingDistanceMax);
        stateTimeLeft = Random.Range(minStateTime, maxStateTime);

        player = GameObject.FindWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!player) {
            return;
        }

        Transform transform = animator.transform;
        Vector3 target = LerpByDistance(player.position, transform.position, stoppingDistance);
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        stateTimeLeft -= Time.deltaTime;
        if (stateTimeLeft <= 0f) {
            if (Random.Range(0f, 1f) > 0.2f) {
                animator.Play("RotateAroundPlayer");
            } else {
                animator.Play("Idle");
            }
        }
    }

    private static Vector3 LerpByDistance(Vector3 from, Vector3 to, float dist)
    {
        return dist * (to - from).normalized + from;
    }
}
