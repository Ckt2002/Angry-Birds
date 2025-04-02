using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyStateMachine stateMachine;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(nameof(ETags.Player)))
            stateMachine.ChangeState(new EnemyColliedState(this));
    }
}