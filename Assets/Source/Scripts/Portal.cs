using System;
using UnityEngine;

[RequireComponent(typeof(ResourceBalance))]
public class Portal : MonoBehaviour
{
    [SerializeField] private ResourceSpawner _resourceSpawner;
    
    private ResourceBalance _resourceBalance;
    
    public event Action Builded;

    private void Awake()
    {
        _resourceBalance = GetComponent<ResourceBalance>();
        _resourceSpawner.ResourceReturned += OnResourceReturned;
        _resourceBalance.MaxResourceCollected += OnMaxResourceCollected;
    }

    private void OnDisable()
    {
        _resourceSpawner.ResourceReturned -= OnResourceReturned;
        _resourceBalance.MaxResourceCollected -= OnMaxResourceCollected;
    }
    
    private void OnResourceReturned() =>
        _ = _resourceBalance.TryIncrement();

    private void OnMaxResourceCollected() =>
        Builded?.Invoke();
}
