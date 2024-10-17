using UnityEngine;
using YG;

namespace Scripts.Pause
{
    public class FullscreenAdPauseSource : PauseSource
    {
        [SerializeField] private YandexGame _yandexGame;
        [SerializeField] private TimerBeforeAdsYG _timerBeforeAds;

        private void Awake()
        {
            _timerBeforeAds.onShowTimer.AddListener(OnShowTimer);
            _yandexGame.CloseFullscreenAd.AddListener(OnCloseFullscreenAd);
        }

        private void OnDestroy()
        {
            _timerBeforeAds.onShowTimer.RemoveListener(OnShowTimer);
            _yandexGame.CloseFullscreenAd.RemoveListener(OnCloseFullscreenAd);
        }

        private void OnShowTimer() =>
            Activate();

        private void OnCloseFullscreenAd() =>
            Deactivate();
    }
}