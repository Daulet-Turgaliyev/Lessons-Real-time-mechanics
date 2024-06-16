using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Example.Security;
using UnityEngine;

namespace Example.Chests
{
    public class ChestTimer
    {
        private readonly ChestView _view;
        private readonly DateTime _openTime;
        private readonly CancellationTokenSource _cancellationTokenSource;
        
        public event Action onTimerEnded = () => { };

        public ChestTimer(ChestView view, DateTime createTime, int openTimeInSeconds)
        {
            _view = view;
            _openTime = createTime.AddSeconds(openTimeInSeconds);
            _cancellationTokenSource = new CancellationTokenSource();


            ServerTimeManagerInitialize();

        }
        
        private async void ServerTimeManagerInitialize()
        {
            await ServerTimeManager.Initialize();
        
            // Example of getting the current server time
            Debug.Log("Current Server Time: " + ServerTimeManager.GetCurrentTime().ToString("yyyy-MM-dd HH:mm:ss"));

            UpdateTimerAsync();
        }

        public void Destroy()
        {
            _cancellationTokenSource.Cancel();
        }
        
        private async void UpdateTimerAsync()
        {

            while (ServerTimeManager.isActualTimeReceived == false)
            {
                await UniTask.Yield(PlayerLoopTiming.Update);
            }
            
            while (_cancellationTokenSource.Token.IsCancellationRequested == false)
            {
                TimeSpan timeRemaining = _openTime - ServerTimeManager.GetCurrentTime();
                
                Debug.Log("Current Server Time: " + ServerTimeManager.GetCurrentTime().ToString("yyyy-MM-dd HH:mm:ss"));

                if (timeRemaining.TotalSeconds > 0)
                {
                    string timerText = string.Format("{0:D2}:{1:D2}:{2:D2}",
                        timeRemaining.Hours,
                        timeRemaining.Minutes,
                        timeRemaining.Seconds);
                    _view.SetTimerText(timerText);
                }
                else
                {
                    _view.SetTimerText("Chest is now open!");
                    onTimerEnded?.Invoke();
                    return;
                }

                await UniTask.Yield(PlayerLoopTiming.Update, cancellationToken: _cancellationTokenSource.Token);
            }

            _view.SetTimerText("Timer cancelled");
        }

    }
}