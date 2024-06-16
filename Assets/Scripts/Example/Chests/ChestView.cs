using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Example.Chests
{
    public class ChestView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinText;
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private Button _openButton;

        public event Action OnOpenButtonClicked = delegate { };

        private void Awake()
        {
            _openButton.onClick.AddListener(() => OnOpenButtonClicked());
        }

        public void SetCoinText(string text)
        {
            _coinText.text = text;
        }

        public void SetTimerText(string text)
        {
            _timerText.text = text;
        }

        public void DestroyOpenButton()
        {
            Destroy(_openButton.gameObject);
        }

        public void SetOpenButtonInteractable(bool interactable)
        {
            _openButton.interactable = interactable;
        }

        
        public void ShowChestOpenedMessage(string message)
        {
            Debug.Log(message);
        }

        public void ShowRewardMessage(string message)
        {
            Debug.Log(message);
        }
    }

}