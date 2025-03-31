using System;
using UnityEngine;

public abstract class BirdController : MonoBehaviour
{
    [SerializeField] private StateMachine stateMachine;
    [SerializeField] private Rigidbody2D rb2D;

    public Rigidbody2D GetRb2D() => rb2D;

    private void Start()
    {
        rb2D.bodyType = RigidbodyType2D.Kinematic;
        rb2D.simulated = false;
    }

    public void BirdGetReady()
    {
        // Jump to slingshot
        // Run rotate animation
    }

    public void BirdFly()
    {
        // Calculate force
    }


    private void OnCollisionEnter(Collision other)
    {
    }

    protected virtual void OnMouseDown()
    {
        SpecialSkill();
    }

    protected virtual void SpecialSkill()
    {
    }
}