using UnityEngine;

public class BirdAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void Idle()
    {
        animator.SetTrigger(nameof(EBirdAnimationName.Idle));
    }

    public void Launching()
    {
        animator.SetTrigger(nameof(EBirdAnimationName.Launching));
    }

    public void Collied()
    {
        animator.SetTrigger(nameof(EBirdAnimationName.Collied));
    }

    public void SpecialSkill()
    {
        animator.SetTrigger(nameof(EBirdAnimationName.SpecialSkill));
    }
}