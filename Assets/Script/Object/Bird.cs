using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private SpriteRenderer objSpriteRenderer;
    [SerializeField] private Collider2D objCollider;
    [SerializeField] private Rigidbody2D objRigidbody;

    private void Start()
    {
        objRigidbody.bodyType = RigidbodyType2D.Kinematic;
    }

    public void Fly(Vector2 force)
    {
        objRigidbody.bodyType = RigidbodyType2D.Dynamic;
        // Thêm lực vào ngay lập tức
        objRigidbody.AddForce(force, ForceMode2D.Impulse);
    }

    public void GetToPosition(Vector2 position)
    {
        transform.position = position;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag(nameof(Tags.Round)))
        {
        }
    }
}