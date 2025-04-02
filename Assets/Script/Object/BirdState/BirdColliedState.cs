using System.Collections;
using UnityEngine;

public class BirdColliedState : IBirdState
{
    private BirdController bird;
    private Coroutine coroutine;

    public BirdColliedState(BirdController bird)
    {
        this.bird = bird;
    }

    public void Enter()
    {
        coroutine = bird.StartCoroutine(WaitAndDisable(5f));
    }

    public void ExecuteOnce()
    {
    }

    private IEnumerator WaitAndDisable(float delay)
    {
        var go = bird.gameObject;
        yield return new WaitForSeconds(delay);
        Exit();
        go.SetActive(false);
    }

    public void ExecuteEveryFrame()
    {
    }

    public void Exit()
    {
        if (coroutine != null && bird != null)
            coroutine = null;
        bird = null;
    }
}