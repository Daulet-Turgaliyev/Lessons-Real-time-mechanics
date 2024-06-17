using System;
using UnityEngine.Serialization;

namespace Example.Rewards
{
    public struct RewardData
    {
        public readonly string rewardType;
        public readonly int quantity;

        public RewardData(string rewardType, int quantity)
        {
            this.rewardType = rewardType;
            this.quantity = quantity;
        }
    }
}