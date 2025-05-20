using System.Collections;
using UnityEngine;

public class TripleSkillColliedState : IBirdState
{
    private BirdController bird;
    private Coroutine coroutine;
    private ParticlePoolingSystem particlePoolingSystem;
    private IBirdAnim anim;
    private string name;
    private SoundManager soundManager;

    public TripleSkillColliedState(BirdController bird, IBirdAnim anim
        , string name, SoundManager soundManager)
    {
        this.bird = bird;
        this.anim = anim;
        this.name = name;
        this.soundManager = soundManager;
        particlePoolingSystem = ParticlePoolingSystem.Instance;
    }

    public void Enter()
    {
        if (particlePoolingSystem == null)
            particlePoolingSystem = ParticlePoolingSystem.Instance;

        anim?.RunCollied();

        coroutine = bird.StartCoroutine(WaitAndDisable());
    }

    public void ExecuteOnce()
    {
    }

    private IEnumerator WaitAndDisable()
    {
        var go = bird.gameObject;
        var particle = particlePoolingSystem?.GetParticle(name);
        particle?.RunParticle(go.transform.position);
        yield return new WaitForSeconds(3f);
        particle?.RunParticle(go.transform.position);
        soundManager.PlaySFXAudioOneShot((int)ESFXAudioClip.BirdDestroy);
        go.SetActive(false);
        Exit();
    }

    public void ExecuteEveryFrame()
    {
    }

    public void Exit()
    {
        if (coroutine != null && bird != null)
        {
            bird?.StopCoroutine(coroutine);
            coroutine = null;
            bird = null;
            particlePoolingSystem = null;
        }
        soundManager = null;
    }
}
