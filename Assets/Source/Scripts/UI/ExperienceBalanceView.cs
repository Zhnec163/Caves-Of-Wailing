using Scripts.Character;
using TMPro;
using UnityEngine;

namespace Scripts.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class ExperienceBalanceView : MonoBehaviour
    {
        [SerializeField] private ExperienceBalance _experienceBalance;

        private TMP_Text _text;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            _experienceBalance.Changed += OnChanged;
            UpdateText(_experienceBalance.Balance.ToString());
        }

        private void OnDestroy() =>
            _experienceBalance.Changed -= OnChanged;

        private void OnChanged() =>
            UpdateText(_experienceBalance.Balance.ToString());

        private void UpdateText(string text) =>
            _text.text = text;
    }
}