using Scripts.Character;
using Scripts.Input;

namespace Scripts.FSMPlayer.States
{
    public abstract class BaseState
    {
        protected readonly StateMachine StateMachine;
        protected readonly PlayerAnimator PlayerAnimator;
        protected readonly InputReader InputReader;

        protected BaseState(StateMachine stateMachine, PlayerAnimator playerAnimator, InputReader inputReader)
        {
            StateMachine = stateMachine;
            PlayerAnimator = playerAnimator;
            InputReader = inputReader;
        }

        public virtual void Enter() { }

        public virtual void Exit() { }

        public virtual void Update() { }

        public virtual void FixedUpdate() { }
    }
}