using Scripts.Character;
using Scripts.Input;

namespace Scripts.FSMPlayer
{
    public abstract class FsmPlayerState
    {
        protected readonly FsmPlayer FsmPlayer;
        protected readonly PlayerAnimator PlayerAnimator;
        protected readonly InputReader InputReader;

        protected FsmPlayerState(FsmPlayer fsmPlayer, PlayerAnimator playerAnimator, InputReader inputReader)
        {
            FsmPlayer = fsmPlayer;
            PlayerAnimator = playerAnimator;
            InputReader = inputReader;
        }

        public virtual void Enter() { }

        public virtual void Exit() { }

        public virtual void Update() { }

        public virtual void FixedUpdate() { }
    }
}