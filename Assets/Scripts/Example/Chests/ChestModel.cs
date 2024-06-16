using System;
using Example.Rewards;

namespace Example.Chests
{
    public class ChestModel
    {
        public readonly RewardData Reward;
        public readonly DateTime TimeToGetChest;
        public readonly int TimeToOpenChest;
        

        public ChestModel(RewardData reward, DateTime timeToGetChest, int timeToOpenChest)
        {
            Reward = reward;
            TimeToGetChest = timeToGetChest;
            TimeToOpenChest = timeToOpenChest;
        }
    }

}