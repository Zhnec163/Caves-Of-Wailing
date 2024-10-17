using System;
using Scripts.Character;
using Scripts.Sound;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Improvement
{
    public class Upgrade : MonoBehaviour
    {
        private const int MaxUpgrade = 3;

        [SerializeField] private int _cost;
        [SerializeField] private int _costMultiplier;
        [SerializeField] private Button _cardButton;

        private int _currentUpgrade;
        private SoundPlayer _soundPlayer;
        private ExperienceBalance _experienceBalance;

        public event Action Upgraded;

        public int Cost => _cost;

        public void Init(SoundPlayer soundPlayer, ExperienceBalance experienceBalance)
        {
            _experienceBalance = experienceBalance;
            _soundPlayer = soundPlayer;
            _cardButton.onClick.AddListener(OnClick);
        }

        private void OnDestroy() =>
            _cardButton.onClick.RemoveListener(OnClick);

        public bool IsMaxUpgrade() =>
            _currentUpgrade == MaxUpgrade;

        private void OnClick() =>
            _ = TryUpgrade();

        private bool TryUpgrade()
        {
            if (_currentUpgrade < MaxUpgrade && _experienceBalance.TrySubtract(_cost))
            {
                _currentUpgrade++;
                _cost *= _costMultiplier;
                _soundPlayer.PlayUpgradeClip();
                Upgraded?.Invoke();
                return true;
            }

            return false;
        }
    }
}