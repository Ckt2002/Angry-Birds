using UnityEngine;

namespace Script.Object.Bird
{
    public class BirdReadyState : IState
    {
        private readonly BirdController bird;
        private Vector2 slingShotReadyPos;

        public BirdReadyState(BirdController bird, Vector2 slingShotReadyPos)
        {
            this.bird = bird;
            this.slingShotReadyPos = slingShotReadyPos;
        }

        public void Enter()
        {
            // Get to slingshot position
        }

        public void ExecuteOnce()
        {
        }

        public void ExecuteEveryFrame()
        {
        }

        public void Exit()
        {
        }
    }
}