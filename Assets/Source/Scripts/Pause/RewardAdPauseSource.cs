using UnityEngine;
using UnityEngine.UI;
using YG;

namespace Scripts.Pause
{
    public class RewardAdPauseSource : PauseSource
    {
        [SerializeField] private YandexGame _yandexGame;
        [SerializeField] private Button _playAdButton;

        private void Awake()
        {
            _playAdButton.onClick.AddListener(OnClick);
            _yandexGame.CloseVideoAd.AddListener(OnCloseVideoAd);
        }

        private void OnDestroy()
        {
            _playAdButton.onClick.RemoveListener(OnClick);
            _yandexGame.CloseVideoAd.RemoveListener(OnCloseVideoAd);
        }

        private void OnClick() =>
            Activate();

        private void OnCloseVideoAd() =>
            Deactivate();
    }
}