using System.Collections;
using UnityEngine;

public class BirdColliedState : IBirdState
{
    private BirdController bird;
    private Coroutine coroutine;
    private ParticlePoolingSystem particlePoolingSystem;
    private IBirdAnim anim;
    private string name;

    public BirdColliedState(BirdController bird, IBirdAnim anim, string name)
    {
        this.bird = bird;
        this.anim = anim;
        this.name = name;
    }

    public void Enter()
    {
        if (particlePoolingSystem == null)
            particlePoolingSystem = ParticlePoolingSystem.Instance;

        anim.RunCollied();
        coroutine = bird.StartCoroutine(WaitAndDisable(5f));
    }

    public void ExecuteOnce()
    {
    }

    private IEnumerator WaitAndDisable(float delay)
    {
        var go = bird.gameObject;
        var particle = particlePoolingSystem?.GetParticle(name);
        particle?.RunParticle(go.transform.position);

        yield return new WaitForSeconds(delay);
        particle?.RunParticle(go.transform.position);
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
        particlePoolingSystem = null;
    }
}