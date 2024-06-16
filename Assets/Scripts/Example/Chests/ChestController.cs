using System;
using Example.Tools;
using System.Globalization;
using Example.Rewards;
using UnityEngine;

namespace Example.Chests
{
    public class ChestController : MonoBehaviour
    {
        private ChestPresenter _presenter;
        public ChestPresenter GetChestPresenter => _presenter;

        [SerializeField, ReadOnly]
        private string chestId;
        [SerializeField]
        private int timeToOpenChest;

        private void Awake()
        {
            var view = GetComponent<ChestView>();
            var chestAnimation = GetComponent<ChestAnimation>();


            RewardData rewardData = new RewardData(500);
            var model = new ChestModel(rewardData, GetTimeToGetChest(), timeToOpenChest);
            _presenter = new ChestPresenter(view, model, chestAnimation);
        }
        
        private void OnDestroy()
        {
            _presenter?.Destroy();
        }

        private DateTime GetTimeToGetChest()
        {
            if (PlayerPrefs.HasKey("SAVE_GET_CHEST_TIME_"+chestId) == false) throw new Exception("No saved DateTime found.");
            
            string savedDateTimeString = PlayerPrefs.GetString("SAVE_GET_CHEST_TIME_"+chestId);
            if (DateTime.TryParse(savedDateTimeString, null, DateTimeStyles.RoundtripKind, out DateTime timeToGetChest))
            {
                return timeToGetChest;
            }

            throw new Exception("Failed to parse saved DateTime.");

        }
        
        
                
#if UNITY_EDITOR


        [ContextMenu("UpdateCreateTime")]
        public void UpdateCreateTime()
        {
            chestId = GetHashCode().ToString();
            DateTime now = DateTime.Now;
            string nowString = now.ToString("o");
            PlayerPrefs.SetString("SAVE_GET_CHEST_TIME_"+chestId, nowString);
            PlayerPrefs.Save(); 
        }
        
#endif
    }

}