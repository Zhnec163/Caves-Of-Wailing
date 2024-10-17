using System;
using UnityEngine;

namespace Scripts.Character
{
    public class ResourceBalance : MonoBehaviour
    {
        [SerializeField] private int _maxResourceAmount;

        public event Action Changed;
        public event Action MaxResourceCollected;

        public int MaxResourceAmount => _maxResourceAmount;

        public int Balance { get; private set; }

        public bool TryIncrement()
        {
            int newAmount = Balance + 1;

            if (newAmount > _maxResourceAmount)
                return false;

            if (newAmount == _maxResourceAmount)
                MaxResourceCollected?.Invoke();

            Balance++;
            Changed?.Invoke();
            return true;
        }
    }
}