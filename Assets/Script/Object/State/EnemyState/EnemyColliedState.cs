using System.Collections;
using UnityEngine;

public class EnemyColliedState : IEnemyState
{
    private EnemyController enemyController;
    private ParticlePoolingSystem particlePoolingSystem;
    private ObjectsActivation objectsActivation;
    private SoundManager soundManager;

    public EnemyColliedState(EnemyController enemyController, SoundManager soundManager)
    {
        this.enemyController = enemyController;
        particlePoolingSystem = ParticlePoolingSystem.Instance;
        objectsActivation = ObjectsActivation.Instance;
        this.soundManager = soundManager;
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
        soundManager.PlaySFXAudioOneShot((int)ESFXAudioClip.PigDamage);
        yield return new WaitForSeconds(0.1f);
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