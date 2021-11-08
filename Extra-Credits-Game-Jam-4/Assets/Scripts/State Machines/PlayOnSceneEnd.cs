using UnityEngine;

public class PlayOnSceneEnd : StateMachineBehaviour
{
    private Animator animator;
    private static readonly int Scene = Animator.StringToHash("endScene");

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this.animator = animator;
        SceneController.OnSceneEnd += EndScene;
    }

    private void EndScene()
    {
        if (animator.parameterCount > 0)
        {
            animator.SetTrigger(Scene);
        }
    }
}
