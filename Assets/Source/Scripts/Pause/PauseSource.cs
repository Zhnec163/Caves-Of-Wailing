using System;
using UnityEngine;

namespace Scripts.Pause
{
    public abstract class PauseSource : MonoBehaviour
    {
        public event Action ActivityChanged;

        public bool IsActive { get; private set; }

        protected void Activate()
        {
            IsActive = true;
            ActivityChanged?.Invoke();
        }

        protected void Deactivate()
        {
            IsActive = false;
            ActivityChanged?.Invoke();
        }
    }
}