using UnityEngine;

public class BirdLaunchState : IBirdState
{
    private Rigidbody2D birdRb;
    private Vector2 launchForce;
    private IBirdAnim anim;
    private SoundManager soundManager;

    public BirdLaunchState(Rigidbody2D birdRb, Vector2 launchForce, IBirdAnim anim, SoundManager soundManager)
    {
        this.birdRb = birdRb;
        this.launchForce = launchForce;
        this.anim = anim;
        this.soundManager = soundManager;
    }

    public void Enter()
    {
        birdRb.bodyType = RigidbodyType2D.Dynamic;
        birdRb.AddForce(launchForce, ForceMode2D.Impulse);
        soundManager.PlaySFXAudioOneShot((int)ESFXAudioClip.BirdFlying);
        ObjectsActivation.Instance.BirdsNumReduce();
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
        soundManager = null;
    }
}