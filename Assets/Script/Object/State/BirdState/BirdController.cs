using Script.Enum;
using UnityEngine;

public abstract class BirdController : MonoBehaviour
{
    public bool skillActive = false;
    public bool launched = false;
    public EBirdType birdType;
    public Rigidbody2D rb2D;

    protected BirdStateMachine stateMachine;
    protected IBirdAnim anim;
    protected new string name;

    private void Awake()
    {
        stateMachine = GetComponent<BirdStateMachine>();
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<IBirdAnim>();
    }

    private void OnEnable()
    {
        Reset();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && launched && !skillActive)
        {
            SpecialSkill();
            skillActive = true;
        }
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
        if (!launched)
            stateMachine.ChangeState(new BirdDragState(this));
    }

    public void BirdLaunchState(Vector2 launchForce)
    {
        if (!launched)
        {
            stateMachine.ChangeState(new BirdLaunchState(rb2D, launchForce, anim));
            launched = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (launched)
            stateMachine.ChangeState(new BirdColliedState(this, anim, name));
    }

    protected void Reset()
    {
        name = gameObject.name.Replace("(Clone)", "");
        rb2D.bodyType = RigidbodyType2D.Kinematic;
        skillActive = false;
        launched = false;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        stateMachine.ChangeState(null);
    }

    protected virtual void SpecialSkill()
    {
    }
}