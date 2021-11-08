using UnityEngine;

public class Blink : StateMachineBehaviour
{
    [SerializeField] private float timeMin = 5f;
    [SerializeField] private float timeMax = 8f;
    private float timeBetween;
    
    private static readonly int DoBlink = Animator.StringToHash("doBlink");

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeBetween = Random.Range(timeMin, timeMax);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timeBetween > 0)
        {
            timeBetween -= Time.deltaTime;
        }
        else
        {
            timeBetween = Random.Range(timeMin, timeMax);
            animator.SetTrigger(DoBlink);
        }
    }
}
