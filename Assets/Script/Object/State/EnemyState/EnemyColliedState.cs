using System.Collections;
using UnityEngine;

public class EnemyColliedState : IEnemyState
{
    private EnemyController enemyController;
    private ParticlePoolingSystem particlePoolingSystem;

    public EnemyColliedState(EnemyController enemyController)
    {
        this.enemyController = enemyController;
        particlePoolingSystem = ParticlePoolingSystem.Instance;
    }

    public void Enter()
    {
        enemyController.StartCoroutine(DieStatus());
    }

    private IEnumerator DieStatus()
    {
        var go = enemyController.gameObject;
        var particle = particlePoolingSystem?.GetParticle(EnemyNames.Pig);
        if (particle != null)
            particle.RunParticle(enemyController.transform.position);
        yield return new WaitForSeconds(0.1f);
        Exit();
        go.SetActive(false);
    }

    public void Exit()
    {
        enemyController = null;
        particlePoolingSystem = null;
    }
}