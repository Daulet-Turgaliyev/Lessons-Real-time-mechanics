using Unity.Plastic.Newtonsoft.Json;

namespace Example.Chests
{
    [System.Serializable]
    public class ChestCollection
    {
        [JsonProperty("chests")]
        public Chest[] Chests { get; set; }
    }
}