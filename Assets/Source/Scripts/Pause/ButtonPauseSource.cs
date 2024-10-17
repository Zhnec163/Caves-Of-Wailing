using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Pause
{
    public class ButtonPauseSource : PauseSource
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Button _resumeButton;

        private void Awake()
        {
            _pauseButton.onClick.AddListener(OnClickPauseButton);
            _resumeButton.onClick.AddListener(OnClickResumeButton);
        }

        private void OnDestroy()
        {
            _pauseButton.onClick.RemoveListener(OnClickPauseButton);
            _resumeButton.onClick.RemoveListener(OnClickResumeButton);
        }

        private void OnClickPauseButton() =>
            Activate();

        private void OnClickResumeButton() =>
            Deactivate();
    }
}