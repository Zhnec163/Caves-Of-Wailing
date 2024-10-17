using System;
using Scripts.Character;
using Scripts.Constant;
using Scripts.Sound;
using Scripts.Struct;
using Scripts.UI;
using UnityEngine;
using YG;

namespace Scripts.Logic
{
    public class GameLogic : MonoBehaviour
    {
        private Portal _portal;
        private EndGameTimer _endGameTimer;
        private ExperienceBalance _experienceBalance;
        private SoundPlayer _soundPlayer;
        private Reward _reward;

        public event Action GameEnded;
        public event Action<Result> Winned;
        public event Action Losed;

        public void Init(
            Portal portal,
            EndGameTimer endGameTimer,
            ExperienceBalance experienceBalance,
            SoundPlayer soundPlayer,
            Reward reward)
        {
            _portal = portal;
            _endGameTimer = endGameTimer;
            _experienceBalance = experienceBalance;
            _soundPlayer = soundPlayer;
            _reward = reward;
            _reward.Canceled += OnCanceled;
            _endGameTimer.Ended += OnEnded;
            _portal.Builded += OnBuilded;
        }

        private void OnDestroy()
        {
            _reward.Canceled -= OnCanceled;
            _endGameTimer.Ended -= OnEnded;
            _portal.Builded -= OnBuilded;
        }

        private void OnBuilded()
        {
            int score = _experienceBalance.TotalBalance * _endGameTimer.Time;

            if (PlayerPrefs.HasKey(PlayerPrefNames.BestScore))
            {
                int bestScore = PlayerPrefs.GetInt(PlayerPrefNames.BestScore);

                if (bestScore < score)
                    YandexGame.NewLeaderboardScores(PlayerPrefNames.TableName, score);
            }

            _soundPlayer.PlayWinClip();
            Winned?.Invoke(new Result(_experienceBalance.TotalBalance, _endGameTimer.Time, score));
            GameEnded?.Invoke();
        }

        private void OnEnded()
        {
            if (_reward.TryShowAds() == false)
                EndGameWithLoss();
        }

        private void OnCanceled() =>
            EndGameWithLoss();

        private void EndGameWithLoss()
        {
            _soundPlayer.PlayLoseClip();
            Losed?.Invoke();
            GameEnded?.Invoke();
        }
    }
}