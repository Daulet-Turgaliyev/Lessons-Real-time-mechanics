using Example.Chests;
using Example.Rewards;
using TMPro;
using UnityEngine;

namespace Example
{
    public class GameCanvasUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _goldCountText;
        [SerializeField] private ChestController[] _chests;

        private int _goldCount;
        private int _diamondCount;
        

        private void Start()
        {
            foreach (var chest in _chests)
            {
                chest.GetChestPresenter.onChestOpened += UpdateData;
            }
        }

        private void OnDestroy()
        {
            foreach (var chest in _chests)
            {
                chest.GetChestPresenter.onChestOpened -= UpdateData;
            }
        }

        private void UpdateData(RewardData rewardData)
        {
            UpdateGold(rewardData.Coins);
        }

        private void UpdateGold(int count)
        {
            _goldCount += count;
            _goldCountText.text = _goldCount.ToString();
        }
        
    }
}