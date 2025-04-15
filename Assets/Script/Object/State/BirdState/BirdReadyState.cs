using UnityEngine;

public class BirdReadyState : IBirdState
{
    private BirdController bird;
    private Vector2 slingShotReadyPos;

    public BirdReadyState(BirdController bird, Vector2 slingShotReadyPos)
    {
        this.bird = bird;
        this.slingShotReadyPos = slingShotReadyPos;
    }

    public void Enter()
    {
        bird.rb2D.simulated = true;
    }

    public void ExecuteOnce()
    {
    }

    public void ExecuteEveryFrame()
    {
        bird.transform.position = Vector2.Lerp(bird.transform.position, slingShotReadyPos, Time.deltaTime * 2);
    }

    public void Exit()
    {
        bird = null;
    }
}