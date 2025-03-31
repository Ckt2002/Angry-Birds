using System;
using System.Collections.Generic;
using Script.Enum;
using UnityEngine;

namespace Script.System
{
    public class BirdSystem : MonoBehaviour
    {
        private BirdPoolingSystem poolingSystem;
        private Dictionary<EBirdType, BirdController[]> birdDictionary;

        private void Start()
        {
            poolingSystem = BirdPoolingSystem.Instance;
            birdDictionary = poolingSystem.birdDictionary;
        }

        public void LoadBirdsInLevel(byte[] birdsNumber)
        {
            if (birdDictionary == null || birdsNumber == null)
                return;

            for (var i = 0; i < birdsNumber.Length; i++)
            {
                if (birdsNumber[i] == 0)
                    continue;

                EBirdType birdType = (EBirdType)i;

                if (!birdDictionary.ContainsKey(birdType))
                    continue;

                for (var j = 0; j < birdsNumber[i]; j++)
                {
                    birdDictionary[birdType][j].gameObject.SetActive(true);
                    // Calculate position
                }
            }
        }
    }
}