using Unity.VisualScripting;
using UnityEngine;

public class BirdMoveInLineState : IBirdState
{
    private BirdController bird;
    private Vector2 newPos;

    public BirdMoveInLineState(BirdController bird)
    {
        this.bird = bird;
    }

    public void Enter()
    {
        newPos = bird.transform.position;
        newPos.x += 2;
    }

    public void ExecuteEveryFrame()
    {
        if (bird != null && Vector2.Distance(bird.transform.position, newPos) > 0.1f)
            bird.transform.position = Vector2.Lerp(bird.transform.position, newPos, Time.deltaTime * 2f);
    }

    public void ExecuteOnce()
    {

    }

    public void Exit()
    {
        bird = null;
    }
}