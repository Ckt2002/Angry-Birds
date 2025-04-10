using System;
using UnityEngine;

public class BirdLaunchState : IBirdState
{
    private Rigidbody2D birdRb;
    private Vector2 launchForce;
    private Action action;
    private IBirdAnim anim;

    public BirdLaunchState(Rigidbody2D birdRb, Vector2 launchForce, IBirdAnim anim, Action action)
    {
        this.birdRb = birdRb;
        this.launchForce = launchForce;
        this.anim = anim;
        this.action = action;
    }

    public void Enter()
    {
        anim.RunLaunch();
        birdRb.bodyType = RigidbodyType2D.Dynamic;
        birdRb.AddForce(launchForce);
        action.Invoke();
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
        action = null;
    }
}