using System;
using UnityEngine;

public class BirdLaunchState : IState
{
    private Rigidbody2D birdRb;
    private Vector2 launchForce;

    public BirdLaunchState(Rigidbody2D birdRb, Vector2 launchForce)
    {
        this.birdRb = birdRb;
        this.launchForce = launchForce;
    }

    public void Enter()
    {
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