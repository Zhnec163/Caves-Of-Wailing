using System.Globalization;
using Scripts.Logic;
using TMPro;
using UnityEngine;

namespace Scripts.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class EndGameTimerView : MonoBehaviour
    {
        [SerializeField] private EndGameTimer _endGameTimer;

        private TMP_Text _text;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            UpdateText(_endGameTimer.Time.ToString(CultureInfo.CurrentCulture));
            _endGameTimer.Changed += OnChanged;
        }

        private void OnDestroy() =>
            _endGameTimer.Changed -= OnChanged;

        private void OnChanged(int time) =>
            UpdateText(time.ToString(CultureInfo.CurrentCulture));

        private void UpdateText(string text) =>
            _text.text = text;
    }
}