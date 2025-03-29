using System;

namespace Script.Object.BirdType
{
    public class BombBird : BirdController
    {
        protected override void SpecialSkill()
        {
            Explode();
        }

        private void Explode()
        {
        }
    }
}