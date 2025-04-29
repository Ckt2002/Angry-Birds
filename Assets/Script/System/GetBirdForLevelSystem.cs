using Script.Enum;
using UnityEngine;

namespace Script.System
{
    public class GetBirdForLevelSystem : MonoBehaviour
    {
        [SerializeField] private BirdPoolingSystem birdPoolingSystem;
        [SerializeField] private BirdProviderSystem birdProviderSystem;

        private Vector2 birdSpawnPos;
        private ObjectsActivation objectsSpawned;

        private void Start()
        {
            objectsSpawned = ObjectsActivation.Instance;
        }

        public void LoadBirdsInLevel(byte[] birdTypes)
        {
            if (birdTypes == null || birdTypes.Length == 0)
                return;

            birdSpawnPos = BirdSpawnPos.Instance.gameObject.transform.position;

            int posCount = 0;
            if (objectsSpawned == null)
                objectsSpawned = ObjectsActivation.Instance;

            objectsSpawned?.InitializationBirds(birdTypes.Length);
            birdProviderSystem.InitializationBirdList(birdTypes.Length);

            foreach (var birdType in birdTypes)
            {
                EBirdType type = (EBirdType)birdType;

                //todo: Update the spawn pos here
                var bird = birdPoolingSystem.GetBirdPool(type);
                bird.gameObject.SetActive(true);
                var offSet = posCount * 2 + 2;
                var pos = new Vector2(birdSpawnPos.x - offSet, birdSpawnPos.y);
                bird.gameObject.transform.position = pos;
                posCount++;

                birdProviderSystem.AddBirdToList(bird);
            }
            birdProviderSystem.ResetIndex();
        }
    }
}