

using System.Collections;
using System.IO;
using Example.Chests;
using UnityEngine;

namespace Example.Tet
{
    public class ChestSpawner : MonoBehaviour
    {
        [SerializeField] private ChestBase _chestBasePrefab;

        private void Start()
        {
            IChestLoadable chestServerLoader = new ChestServerLoader();
            ChestCollection chestCollection = chestServerLoader.LoadChestsFromServer();

            foreach (var chestData in chestCollection.Chests)
            {
                ChestBase chestBase = Instantiate(_chestBasePrefab, transform);
                chestBase.
                    Initialize(chestData);
            }
        }
    }
}