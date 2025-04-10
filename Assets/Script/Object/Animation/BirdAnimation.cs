using UnityEngine;

public class BirdAnimation : MonoBehaviour, IBirdAnim
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void RunCollied()
    {
        animator.SetTrigger(nameof(EBirdAnimationName.Collied));
    }

    public void RunLaunch()
    {
        animator.SetTrigger(nameof(EBirdAnimationName.Launching));
    }

    public void RunIdle()
    {
        animator.SetTrigger(nameof(EBirdAnimationName.Idle));
    }

    public void RunSpecialSkill()
    {
        animator.SetTrigger(nameof(EBirdAnimationName.SpecialSkill));
    }
}