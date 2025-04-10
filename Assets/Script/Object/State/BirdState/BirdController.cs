using Script.Enum;
using UnityEngine;

public abstract class BirdController : MonoBehaviour
{
    private BirdStateMachine stateMachine;
    private Rigidbody2D rb2D;
    private IBirdAnim anim;
    private bool launched = false;
    private new string name;


    public EBirdType birdType;
    public Rigidbody2D GetRb2D() => rb2D;

    private void Start()
    {
        stateMachine = GetComponent<BirdStateMachine>();
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<IBirdAnim>();

        name = gameObject.name.Replace("(Clone)", "");
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
        stateMachine.ChangeState(new BirdLaunchState(rb2D, launchForce, anim, () => launched = true));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (launched)
            stateMachine.ChangeState(new BirdColliedState(this, anim, name));
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