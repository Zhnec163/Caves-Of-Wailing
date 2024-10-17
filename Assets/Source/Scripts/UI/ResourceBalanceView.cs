using Scripts.Character;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI
{
    [RequireComponent(typeof(Slider))]
    public class ResourceBalanceView : MonoBehaviour
    {
        [SerializeField] private ResourceBalance _resourceBalance;
        [SerializeField] private TMP_Text _text;

        private Slider _slider;

        private void Awake()
        {
            _resourceBalance.Changed += OnChanged;
            UpdateText($"{_resourceBalance.Balance} / {_resourceBalance.MaxResourceAmount}");
            _slider = GetComponent<Slider>();
            _slider.maxValue = _resourceBalance.MaxResourceAmount;
        }

        private void OnDestroy() =>
            _resourceBalance.Changed -= OnChanged;

        private void OnChanged()
        {
            UpdateText($"{_resourceBalance.Balance} / {_resourceBalance.MaxResourceAmount}");
            _slider.value = _resourceBalance.Balance;
        }

        private void UpdateText(string text) =>
            _text.text = text;
    }
}