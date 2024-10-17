using System;
using Scripts.Character;
using Scripts.Creator;
using UnityEngine;

namespace Scripts.Logic
{
    [RequireComponent(typeof(ResourceBalance))]
    public class Portal : MonoBehaviour
    {
        private ResourceSpawner _resourceSpawner;
        private ResourceBalance _resourceBalance;

        public event Action Builded;

        public void Init(ResourceSpawner resourceSpawner)
        {
            _resourceSpawner = resourceSpawner;
            _resourceBalance = GetComponent<ResourceBalance>();
            _resourceSpawner.ResourceReturned += OnResourceReturned;
            _resourceBalance.MaxResourceCollected += OnMaxResourceCollected;
        }

        private void OnDestroy()
        {
            _resourceSpawner.ResourceReturned -= OnResourceReturned;
            _resourceBalance.MaxResourceCollected -= OnMaxResourceCollected;
        }

        private void OnResourceReturned() =>
            _ = _resourceBalance.TryIncrement();

        private void OnMaxResourceCollected() =>
            Builded?.Invoke();
    }
}