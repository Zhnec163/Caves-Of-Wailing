using System;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    private const int MaxUpgrade = 3;

    [SerializeField] private int _cost;
    [SerializeField] private int _costMultiplier;
    [SerializeField] private ExperienceBalance _experienceBalance;
    [SerializeField] private Button _cardButton;

    private int _currentUpgrade;

    public event Action Upgraded;

    public int Cost => _cost;

    private void Awake() =>
        _cardButton.onClick.AddListener(OnClick);

    private void OnDisable() =>
        _cardButton.onClick.RemoveListener(OnClick);

    public bool IsComplete() =>
        _currentUpgrade == MaxUpgrade;

    private void OnClick() =>
        _ = TryUpgrade();

    private bool TryUpgrade()
    {
        if (_currentUpgrade < MaxUpgrade && _experienceBalance.TrySubtract(_cost))
        {
            _currentUpgrade++;
            _cost *= _costMultiplier;
            Upgraded?.Invoke();
            return true;
        }

        return false;
    }
}