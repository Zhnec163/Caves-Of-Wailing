using System;
using Scripts.Logic;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace Scripts.UI
{
    public class Reward : MonoBehaviour
    {
        private const int Id = 1;

        [SerializeField] public int _extraTime;
        [SerializeField] private Button _confirmation;
        [SerializeField] private Button _cancellation;
        [SerializeField] private EndGameTimer _endGameTimer;
        [SerializeField] private UserInterfaceController _userInterfaceController;

        private bool _isShown;

        public event Action Canceled;

        private void Awake()
        {
            YandexGame.RewardVideoEvent += OnRewarded;
            _confirmation.onClick.AddListener(OnClickConfirmation);
            _cancellation.onClick.AddListener(OnClickCancellation);
        }

        private void OnDestroy()
        {
            YandexGame.RewardVideoEvent -= OnRewarded;
            _confirmation.onClick.AddListener(OnClickConfirmation);
            _cancellation.onClick.AddListener(OnClickCancellation);
        }

        public bool TryShowAds()
        {
            if (_isShown)
                return false;

            _isShown = true;
            _userInterfaceController.ShowRewardPopup();
            return true;
        }

        private void OnRewarded(int _) =>
            _endGameTimer.AddTime(_extraTime);

        private void OnClickConfirmation()
        {
            _userInterfaceController.CloseRewardPopup();
            YandexGame.RewVideoShow(Id);
        }

        private void OnClickCancellation()
        {
            _userInterfaceController.CloseRewardPopup();
            Canceled?.Invoke();
        }
    }
}