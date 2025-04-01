using Script.Enum;
using UnityEngine;

namespace Script.System
{
    public class GetBirdForLevelSystem : MonoBehaviour
    {
        private Vector2 birdSpawnPos;
        [SerializeField] private BirdPoolingSystem birdPoolingSystem;
        [SerializeField] private BirdProviderSystem slingshotSystem;

        public void LoadBirdsInLevel(byte[] birdTypes)
        {
            if (birdTypes == null || birdTypes.Length == 0)
                return;

            birdSpawnPos = BirdSpawnPos.Instance.gameObject.transform.position;

            int posCount = 0;
            foreach (var birdType in birdTypes)
            {
                EBirdType type = (EBirdType)birdType;

                var bird = birdPoolingSystem.GetBirdPool(type);
                bird.gameObject.SetActive(true);
                var offSet = posCount * 2 + 2;
                var pos = new Vector2(birdSpawnPos.x - offSet, birdSpawnPos.y);
                bird.gameObject.transform.position = pos;
                slingshotSystem.AddBirdToQueue(bird);
                posCount++;
            }
        }
    }
}