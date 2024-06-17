using System;
using System.Globalization;
using Example.Rewards;
using UnityEngine;

namespace Example.Chests
{
    public class ChestBase : MonoBehaviour
    {
        private ChestPresenter _presenter;
        private ChestAnimation _chestAnimation;


        private void Start()
        {
            Chest chest = new Chest();
            chest.ReceivedTime = "2024-06-17T11:30:00Z";
            chest.Amount = 150000;
            chest.TimeToOpen = 5;
            Initialize(chest);
        }

        public void Initialize(Chest chest)
        {
            var view = GetComponent<ChestView>();
            _chestAnimation = GetComponent<ChestAnimation>();

            DateTime createTime = ConvertDataTime(chest.ReceivedTime);
            var model = new ChestModel(chest, createTime);
            
            _presenter = new ChestPresenter(view, model);
            _presenter.onChestOpened += ChestOpened;
        }

        private void ChestOpened(RewardData rewardData)
        {
            ScoreManager.Instance.AddPoints(rewardData.quantity);
            _chestAnimation.Open();
        }
        
        private void OnDestroy()
        {
            _presenter.onChestOpened -= ChestOpened;

            _presenter?.Destroy();
        }

        private DateTime ConvertDataTime(string dataTime)
        {
            
            if (DateTime.TryParse(dataTime, null, DateTimeStyles.RoundtripKind, out DateTime timeToGetChest))
            {
                return timeToGetChest;
            }

            throw new Exception("Failed to parse saved DateTime.");

        }
    }

}