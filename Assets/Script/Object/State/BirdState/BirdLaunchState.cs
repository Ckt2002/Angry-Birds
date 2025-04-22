using UnityEngine;

public class BirdLaunchState : IBirdState
{
    private Rigidbody2D birdRb;
    private Vector2 launchForce;
    private IBirdAnim anim;

    public BirdLaunchState(Rigidbody2D birdRb, Vector2 launchForce, IBirdAnim anim)
    {
        this.birdRb = birdRb;
        this.launchForce = launchForce;
        this.anim = anim;
    }

    public void Enter()
    {
        birdRb.bodyType = RigidbodyType2D.Dynamic;
        birdRb.AddForce(launchForce, ForceMode2D.Impulse);
    }

    public void ExecuteOnce()
    {
    }

    public void ExecuteEveryFrame()
    {
    }

    public void Exit()
    {
        birdRb = null;
    }
}