using System;
using Example.Rewards;
using UnityEngine;

namespace Example.Chests
{
    public class ChestPresenter
    {
        private readonly ChestView _view;
        private readonly ChestModel _model;
        private readonly ChestTimer _chestTimer;
        
        public event Action<RewardData> onChestOpened = delegate {  };

        public ChestPresenter(ChestView view, ChestModel model)
        {
            _view = view;
            _model = model;

            _chestTimer = new ChestTimer(view, model.TimeToGetChest, model.TimeToOpenChest);
            _chestTimer.onTimerEnded += ActivateOpenButton;

            _view.SetCoinText(model.RewardData.quantity.ToString());
            _view.OnOpenButtonClicked += OpenChest;
        }

        private void ActivateOpenButton()
        { 
            _view.SetOpenButtonInteractable(true);
        }

        private void OpenChest()
        {
            _view.DestroyOpenButton();
            onChestOpened?.Invoke(_model.RewardData);
        }

        public void Destroy()
        {
            _chestTimer.Destroy();
            _chestTimer.onTimerEnded -= ActivateOpenButton;
            _view.OnOpenButtonClicked -= OpenChest;
        }
    }
}