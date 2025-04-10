using System.Collections;
using UnityEngine;

public class ObstacleColliedState : IObstacleState
{
    private ObstacleController obstacleController;
    private ParticlePoolingSystem particlePoolingSystem;

    public ObstacleColliedState(ObstacleController obstacleController)
    {
        this.obstacleController = obstacleController;
        particlePoolingSystem = ParticlePoolingSystem.Instance;
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
        yield return new WaitForSeconds(0.1f);
        Exit();
        go.SetActive(false);
    }

    public void Exit()
    {
        obstacleController = null;
        particlePoolingSystem = null;
    }
}