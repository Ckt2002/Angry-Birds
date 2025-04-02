using System.Collections;
using UnityEngine;

public class EnemyColliedState : IEnemyState
{
    private EnemyController enemyController;
    private ParticleSystem effect;

    public EnemyColliedState(EnemyController enemyController, ParticleSystem effect = null)
    {
        this.enemyController = enemyController;
        this.effect = effect;
    }

    public void Enter()
    {
        enemyController.StartCoroutine(DieStatus());
    }

    private IEnumerator DieStatus()
    {
        var go = enemyController.gameObject;
        if (effect != null)
        {
            effect.transform.position = enemyController.transform.position;
            effect.Play();
        }
        yield return new WaitForSeconds(1f);
        Exit();
        go.SetActive(false);
    }

    public void Exit()
    {
        enemyController = null;
        effect = null;
    }
}