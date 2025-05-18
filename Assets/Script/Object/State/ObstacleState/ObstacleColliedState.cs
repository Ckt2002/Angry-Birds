using System.Collections;
using UnityEngine;

public class ObstacleColliedState : IObstacleState
{
    private ObstacleController obstacleController;
    private ParticlePoolingSystem particlePoolingSystem;
    private SoundManager soundManager;
    private string particleName;

    public ObstacleColliedState(ObstacleController obstacleController
        , SoundManager soundManager, string particleName)
    {
        this.obstacleController = obstacleController;
        particlePoolingSystem = ParticlePoolingSystem.Instance;
        this.soundManager = soundManager;
        this.particleName = particleName;
    }

    public void Enter()
    {
        obstacleController.StartCoroutine(DestroyStatus());
    }

    private IEnumerator DestroyStatus()
    {
        var go = obstacleController.gameObject;
        var particle = particlePoolingSystem?.GetParticle(particleName);
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