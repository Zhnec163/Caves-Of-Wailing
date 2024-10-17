using System.Collections.Generic;
using System.Linq;
using Scripts.Logic;
using UnityEngine;

namespace Scripts.Pause
{
    public class PauseController : MonoBehaviour
    {
        private List<PauseSource> _pauseSources;
        private GameLogic _gameLogic;
        private bool _isListenSources = true;

        public void Init(GameLogic gameLogic, List<PauseSource> pauseSources)
        {
            _gameLogic = gameLogic;
            _pauseSources = pauseSources;
            _gameLogic.GameEnded += OnGameEnded;
            _pauseSources.ForEach(source => source.ActivityChanged += OnChanged);
        }

        private void OnDestroy()
        {
            _gameLogic.GameEnded -= OnGameEnded;
            _pauseSources.ForEach(source => source.ActivityChanged -= OnChanged);
        }

        private void OnGameEnded()
        {
            SetTimeScaleToZero();
            _isListenSources = false;
        }

        private void OnChanged()
        {
            if (_isListenSources == false)
                return;

            if (AnySourceActive())
                Pause();
            else
                Unpause();
        }

        private void Pause()
        {
            AudioListener.pause = true;
            SetTimeScaleToZero();
        }

        private void Unpause()
        {
            AudioListener.pause = false;
            SetTimeScaleToOne();
        }

        private void SetTimeScaleToZero() =>
            Time.timeScale = 0F;

        private void SetTimeScaleToOne() =>
            Time.timeScale = 1F;

        private bool AnySourceActive() =>
            _pauseSources.Any(source => source.IsActive);
    }
}