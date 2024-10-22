using Scripts.Character;
using Scripts.Input;

namespace Scripts.FSMPlayer.States
{
    public class Run : BaseState
    {
        private readonly PlayerMover _playerMover;

        public Run(
            StateMachine stateMachine,
            PlayerAnimator playerAnimator,
            InputReader inputReader,
            PlayerMover playerMover)
            : base(stateMachine, playerAnimator, inputReader)
        {
            _playerMover = playerMover;
        }

        public override void Enter() =>
            PlayerAnimator.PlayRunAnimation();

        public override void Update()
        {
            if (InputReader.NotHaveInput())
                StateMachine.SetState<Idle>();
        }

        public override void FixedUpdate() =>
            _playerMover.Move(InputReader.Input);
    }
}