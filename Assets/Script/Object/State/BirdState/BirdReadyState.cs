using UnityEngine;

public class BirdReadyState : IBirdState
{
    private BirdController bird;
    private Vector2 slingShotReadyPos;
    private SoundManager soundManager;

    public BirdReadyState(BirdController bird, Vector2 slingShotReadyPos, SoundManager soundManager)
    {
        this.bird = bird;
        this.slingShotReadyPos = slingShotReadyPos;
        this.soundManager = soundManager;
    }

    public void Enter()
    {
        bird.rb2D.simulated = true;
        soundManager.PlaySFXAudioOneShot((int)ESFXAudioClip.BirdSelect);
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
        soundManager = null;
    }
}