using System.Collections;
using UnityEngine;

public class EnemyColliedState : IEnemyState
{
    private EnemyController enemyController;
    private ParticlePoolingSystem particlePoolingSystem;
    private ObjectsActivation objectsActivation;
    private SoundManager soundManager;

    public EnemyColliedState(EnemyController enemyController
        , SoundManager soundManager, ObjectsActivation objectsActivation)
    {
        this.enemyController = enemyController;
        particlePoolingSystem = ParticlePoolingSystem.Instance;
        this.objectsActivation = objectsActivation;
        this.soundManager = soundManager;
    }

    public void Enter()
    {
        if (particlePoolingSystem == null)
            particlePoolingSystem = ParticlePoolingSystem.Instance;

        if (objectsActivation == null)
            objectsActivation = ObjectsActivation.Instance;

        enemyController.StartCoroutine(DieStatus());
    }

    private IEnumerator DieStatus()
    {
        var go = enemyController.gameObject;
        var particle = particlePoolingSystem?.GetParticle(EnemyNames.Pig);
        particle.RunParticle(enemyController.transform.position);
        soundManager.PlaySFXAudioOneShot((int)ESFXAudioClip.PigDamage);
        yield return new WaitForSeconds(0.1f);

        if (objectsActivation == null)
        {
            objectsActivation = ObjectsActivation.Instance;
        }
        objectsActivation.EnemiesNumReduce();
        Exit();
        go.SetActive(false);
    }

    public void Exit()
    {
        enemyController = null;
        particlePoolingSystem = null;
        objectsActivation = null;
        soundManager = null;
    }
}