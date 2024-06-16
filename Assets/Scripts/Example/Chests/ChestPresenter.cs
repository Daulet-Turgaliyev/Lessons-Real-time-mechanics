using System;
using Example.Rewards;

namespace Example.Chests
{
    public class ChestPresenter
    {
        private readonly ChestView _view;
        private readonly ChestModel _model;
        private readonly ChestTimer _chestTimer;
        private readonly ChestAnimation _chestAnimation;
        
        public event Action<RewardData> onChestOpened = delegate {  };

        public ChestPresenter(ChestView view, ChestModel model, ChestAnimation chestAnimation)
        {
            _view = view;
            _model = model;
            _chestAnimation = chestAnimation;

            _chestTimer = new ChestTimer(view, model.TimeToGetChest, model.TimeToOpenChest);
            _chestTimer.onTimerEnded += ActivateOpenButton;

            _view.SetCoinText(model.Reward.Coins.ToString());
            _view.OnOpenButtonClicked += OpenChest;
        }

        private void ActivateOpenButton()
        { 
            _view.SetOpenButtonInteractable(true);
        }

        private void OpenChest()
        {
            _chestAnimation.Open();
            _view.ShowChestOpenedMessage("Вы открыли сундук с золотом!");
            _view.ShowRewardMessage($"Вы получили: {_model.Reward.Coins}");
            _view.DestroyOpenButton();
            
            onChestOpened?.Invoke(_model.Reward);
        }

        public void Destroy()
        {
            _chestTimer.Destroy();
            _chestTimer.onTimerEnded -= ActivateOpenButton;
            _view.OnOpenButtonClicked -= OpenChest;
        }
    }
}