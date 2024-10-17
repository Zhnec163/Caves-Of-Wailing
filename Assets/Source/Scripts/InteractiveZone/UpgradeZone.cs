using System;
using Scripts.Character;
using UnityEngine;

namespace Scripts.InteractiveZone
{
    public class UpgradeZone : MonoBehaviour
    {
        public event Action PlayerEntered;
        public event Action PlayerExited;

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out Player _))
                PlayerEntered?.Invoke();
        }

        private void OnTriggerExit(Collider collider)
        {
            if (collider.TryGetComponent(out Player _))
                PlayerExited?.Invoke();
        }
    }
}