using UnityEngine;

namespace Scripts.Character
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour
    {
        private const string IsRunning = nameof(IsRunning);
        private const string IsWorking = nameof(IsWorking);

        private Animator _animator;

        public void Awake() =>
            _animator = GetComponent<Animator>();

        public void PlayIdleAnimation()
        {
            _animator.SetBool(IsRunning, false);
            _animator.SetBool(IsWorking, false);
        }

        public void PlayRunAnimation()
        {
            _animator.SetBool(IsRunning, true);
            _animator.SetBool(IsWorking, false);
        }

        public void PlayCollectAnimation()
        {
            _animator.SetBool(IsRunning, false);
            _animator.SetBool(IsWorking, true);
        }
    }
}