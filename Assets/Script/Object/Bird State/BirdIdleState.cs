using UnityEngine;

namespace Script.Object.Bird
{
    public class BirdIdleState : IState
    {
        private readonly BirdController bird;

        public BirdIdleState(BirdController bird)
        {
            this.bird = bird;
        }

        public void Enter()
        {
            // Play Idle animation
            bird.GetRb2D().bodyType = RigidbodyType2D.Dynamic;
        }

        public void ExecuteOnce()
        {
            // Nothing to do
        }

        public void ExecuteEveryFrame()
        {
            // Nothing to do
        }

        public void Exit()
        {
        }
    }
}