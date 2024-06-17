using System;
using System.IO;
using Example.Chests;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

namespace Example
{
    public class ChestServerLoader: IChestLoadable
    {
        private const string JSON_FILE = "chestData.json";

        public ChestCollection LoadChestsFromServer()
        {
            string filePath = Path.Combine(Application.streamingAssetsPath, JSON_FILE);

            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);
                ChestCollection chestCollection = JsonConvert.DeserializeObject<ChestCollection>(jsonContent);

                return chestCollection;
            }

            throw new Exception("JSON file not found at " + filePath);
        }
    }
}