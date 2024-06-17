using System;
using Example.Rewards;

namespace Example.Chests
{
    public class ChestModel
    {
        public readonly RewardData RewardData;
        public readonly DateTime TimeToGetChest;
        public readonly int TimeToOpenChest;
        

        public ChestModel(Chest chest, DateTime timeToGetChest)
        {
            RewardData = new RewardData(chest.RewardType, chest.Amount);
            TimeToGetChest = timeToGetChest;
            TimeToOpenChest = chest.TimeToOpen;
        }
    }

}