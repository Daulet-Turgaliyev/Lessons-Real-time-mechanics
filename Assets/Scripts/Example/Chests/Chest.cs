using Unity.Plastic.Newtonsoft.Json;

namespace Example.Chests
{
    [System.Serializable]
    public class Chest
    {
        [JsonProperty("rewardType")]
        public string RewardType { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("received_time")]
        public string ReceivedTime { get; set; }

        [JsonProperty("timeToOpen")]
        public int TimeToOpen { get; set; }
    }
}