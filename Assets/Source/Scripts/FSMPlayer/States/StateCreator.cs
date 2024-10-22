using Scripts.Character;
using Scripts.Detector;
using Scripts.Input;

namespace Scripts.FSMPlayer.States
{
    public class StateCreator
    {
        private readonly StateMachine _stateMachine;
        private readonly PlayerAnimator _playerAnimator;
        private readonly InputReader _inputReader;
        private readonly Backpack _backpack;
        private readonly OreDetector _oreDetector;

        public StateCreator(
            StateMachine stateMachine,
            PlayerAnimator playerAnimator,
            InputReader inputReader,
            Backpack backpack,
            OreDetector oreDetector)
        {
            _stateMachine = stateMachine;
            _playerAnimator = playerAnimator;
            _inputReader = inputReader;
            _backpack = backpack;
            _oreDetector = oreDetector;
        }

        public BaseState CreateStateIdle(BuildZoneDetector buildZoneDetector) =>
            new Idle(
                _stateMachine,
                _playerAnimator,
                _inputReader,
                _oreDetector,
                _backpack,
                buildZoneDetector);

        public BaseState CreateStateRun(PlayerMover playerMover) =>
            new Run(
                _stateMachine,
                _playerAnimator,
                _inputReader,
                playerMover);

        public BaseState CreateStateCollect(
            float collectTime, ExperienceBalance experienceBalance) =>
            new Collect(
                _stateMachine,
                _playerAnimator,
                _inputReader,
                _oreDetector,
                _backpack,
                collectTime,
                experienceBalance);

        public BaseState CreateStateDischarge(float dischargeTime) =>
            new Discharge(_stateMachine, _playerAnimator, _inputReader, _backpack, dischargeTime);
    }
}