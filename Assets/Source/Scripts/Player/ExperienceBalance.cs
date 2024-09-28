using System;
using UnityEngine;

public class ExperienceBalance : MonoBehaviour 
{
    [SerializeField] private int _increment;
    [SerializeField] private int _incrementForUpgrade;
    [SerializeField] private Upgrade _upgrade;
    
    public event Action Changed;

    public int Balance { get; private set; }
    public int TotalBalance { get; private set; }

    private void Awake() =>
        _upgrade.Upgraded += OnUpgraded;
    
    private void OnDisable() =>
        _upgrade.Upgraded -= OnUpgraded;
    
    public void Increment()
    {
        Balance += _increment;
        TotalBalance += _increment;
        Changed?.Invoke();
    }

    public bool TrySubtract(int amount)
    {
        if (Balance < amount)
            return false;

        Balance -= amount;
        Changed?.Invoke();
        return true;
    }
    
    private void OnUpgraded() =>
        _increment += _incrementForUpgrade;
}