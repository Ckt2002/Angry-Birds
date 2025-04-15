using UnityEngine;

public class EnemyExplosionState : IEnemyState
{
    private Rigidbody2D rb2D;
    private float explosionForce;
    private Vector2 direction;

    public EnemyExplosionState(Rigidbody2D rb2D, float explosionForce, Vector2 direction)
    {
        this.rb2D = rb2D;
        this.explosionForce = explosionForce;
        this.direction = direction;
    }

    public void Enter()
    {
        if (rb2D != null)
            rb2D.AddForce(direction * explosionForce, ForceMode2D.Impulse);

        rb2D = null;
    }

    public void Exit()
    {
        if (rb2D != null)
            rb2D = null;
    }
}
