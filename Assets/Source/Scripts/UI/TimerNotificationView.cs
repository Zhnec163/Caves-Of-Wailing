using DG.Tweening;
using Scripts.Logic;
using TMPro;
using UnityEngine;

namespace Scripts.UI
{
    public class TimerNotificationView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private EndGameTimer _endGameTimer;
        [SerializeField] private float _showTime;

        private Tween _upscaleAnimation;

        private void Awake() =>
            _endGameTimer.Deducted += OnDeducted;

        private void OnDestroy() =>
            _endGameTimer.Deducted -= OnDeducted;

        private void OnDeducted()
        {
            _upscaleAnimation.Kill();
            _text.rectTransform.localScale = Vector3.zero;
            _text.gameObject.SetActive(true);
            _upscaleAnimation = _text.rectTransform.DOScale(Vector3.one, _showTime).OnComplete(CloseNotification);
        }

        private void CloseNotification() =>
            _text.gameObject.SetActive(false);
    }
}