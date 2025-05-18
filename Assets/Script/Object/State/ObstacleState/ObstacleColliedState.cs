using System.Collections;
using UnityEngine;

public class ObstacleColliedState : IObstacleState
{
    private ObstacleController obstacleController;
    private ParticlePoolingSystem particlePoolingSystem;
    private SoundManager soundManager;

    public ObstacleColliedState(ObstacleController obstacleController, SoundManager soundManager)
    {
        this.obstacleController = obstacleController;
        particlePoolingSystem = ParticlePoolingSystem.Instance;
        this.soundManager = soundManager;
    }

    public void Enter()
    {
        obstacleController.StartCoroutine(DestroyStatus());
    }

    private IEnumerator DestroyStatus()
    {
        var go = obstacleController.gameObject;
        var particle = particlePoolingSystem?.GetParticle(ObstacleNames.Obstacle);
        if (particle != null)
            particle.RunParticle(obstacleController.transform.position);
        soundManager.PlaySFXAudioOneShot((int)ESFXAudioClip.WoodDestroy);
        yield return new WaitForSeconds(0.1f);
        Exit();
        go.SetActive(false);
    }

    public void Exit()
    {
        obstacleController = null;
        particlePoolingSystem = null;
        soundManager = null;
    }
}