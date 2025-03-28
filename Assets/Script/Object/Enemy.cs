using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer objSpriteRenderer;
    [SerializeField] private Collider2D objCollider;
    [SerializeField] private Rigidbody2D objRigidbody;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains(nameof(Tags.Player))) Die();
    }

    private void Die()
    {
        EnemySystem.Instance.EnemyReduce();
        // Run particle
        objSpriteRenderer.enabled = false;
        objCollider.enabled = false;
    }
}