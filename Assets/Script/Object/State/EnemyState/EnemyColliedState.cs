using System.Collections;
using UnityEngine;

public class EnemyColliedState : IEnemyState
{
    private EnemyController enemyController;
    private ParticlePoolingSystem particlePoolingSystem;
    private ObjectsActivation objectsActivation;

    public EnemyColliedState(EnemyController enemyController)
    {
        this.enemyController = enemyController;
        particlePoolingSystem = ParticlePoolingSystem.Instance;
        objectsActivation = ObjectsActivation.Instance;
    }

    public void Enter()
    {
        if (particlePoolingSystem == null)
            particlePoolingSystem = ParticlePoolingSystem.Instance;

        if (objectsActivation == null)
            objectsActivation = ObjectsActivation.Instance;

        objectsActivation?.EnemiesNumReduce();
        enemyController.StartCoroutine(DieStatus());
    }

    private IEnumerator DieStatus()
    {
        var go = enemyController.gameObject;
        var particle = particlePoolingSystem?.GetParticle(EnemyNames.Pig);
        particle.RunParticle(enemyController.transform.position);
        yield return new WaitForSeconds(0.1f);
        Exit();
        go.SetActive(false);
    }

    public void Exit()
    {
        enemyController = null;
        particlePoolingSystem = null;
        objectsActivation = null;
    }
}