using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ResourceBalanceView : MonoBehaviour
{
    [SerializeField] private ResourceBalance _resourceBalance;
    [SerializeField] private TMP_Text _text;

    private Slider _slider;

    private void Awake()
    {
        _resourceBalance.Changed += OnChanged;
        _text.text = $"{_resourceBalance.Balance} / {_resourceBalance.MaxResourceAmount}";
        _slider = GetComponent<Slider>();
        _slider.maxValue = _resourceBalance.MaxResourceAmount;
    }

    private void OnDestroy() =>
        _resourceBalance.Changed -= OnChanged;

    private void OnChanged()
    {
        _text.text = $"{_resourceBalance.Balance} / {_resourceBalance.MaxResourceAmount}";
        _slider.value = _resourceBalance.Balance;
    }
}
