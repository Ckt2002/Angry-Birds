using UnityEngine;

public abstract class BirdController : MonoBehaviour
{
    [SerializeField] private BirdStateMachine stateMachine;
    [SerializeField] private BirdAnimation anim;
    [SerializeField] private Rigidbody2D rb2D;

    public Rigidbody2D GetRb2D() => rb2D;
    private bool launched = false;

    private void Start()
    {
        rb2D.bodyType = RigidbodyType2D.Kinematic;
        rb2D.simulated = false;
    }

    public void MoveInLineState()
    {
        stateMachine.ChangeState(new BirdMoveInLineState(this));
    }

    public void BirdGetReadyState(Vector2 readyPos)
    {
        stateMachine.ChangeState(new BirdReadyState(this, readyPos));
    }

    public void BirdDragState()
    {
        stateMachine.ChangeState(new BirdDragState(this));
    }

    public void BirdLaunchState(Vector2 launchForce)
    {
        stateMachine.ChangeState(new BirdLaunchState(rb2D, launchForce, () => launched = true));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (launched)
            stateMachine.ChangeState(new BirdColliedState(this));
    }

    protected virtual void OnMouseDown()
    {
        SpecialSkill();
    }

    protected virtual void SpecialSkill()
    {
        // override in children
    }
}