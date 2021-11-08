using UnityEngine;

public class EnemyIdle : StateMachineBehaviour
{
    [Header("State Transition")]
    [SerializeField] private float minStateTime;
    [SerializeField] private float maxStateTime;

    private float stateTimeLeft;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stateTimeLeft = Random.Range(minStateTime, maxStateTime);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stateTimeLeft -= Time.deltaTime;
        if (stateTimeLeft <= 0f) {
            if (Random.Range(0f, 1f) > 0.5f) {
                animator.Play("RotateAroundPlayer");
            } else {
                animator.Play("MoveTowardsPlayer");
            }
        }
    }
}
