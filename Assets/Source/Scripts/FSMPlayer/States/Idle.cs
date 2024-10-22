using Scripts.Character;
using Scripts.Detector;
using Scripts.Input;
using Scripts.Interactive.Ore;

namespace Scripts.FSMPlayer.States
{
    public class Idle : BaseState
    {
        private readonly OreDetector _oreDetector;
        private readonly BuildZoneDetector _buildZoneDetector;
        private readonly Backpack _backpack;

        public Idle(
            StateMachine stateMachine,
            PlayerAnimator playerAnimator,
            InputReader inputReader,
            OreDetector oreDetector,
            Backpack backpack,
            BuildZoneDetector buildZoneDetector)
            : base(stateMachine, playerAnimator, inputReader)
        {
            _oreDetector = oreDetector;
            _backpack = backpack;
            _buildZoneDetector = buildZoneDetector;
        }

        public override void Enter() =>
            PlayerAnimator.PlayIdleAnimation();

        public override void Update()
        {
            if (InputReader.HaveInput())
                StateMachine.SetState<Run>();
            else if (_oreDetector.TryGetOre(out Ore ore) && ore.IsNotEmpty() && _backpack.IsNotFull())
                StateMachine.SetState<Collect>();
            else if (_buildZoneDetector.IsInner && _backpack.HaveResources())
                StateMachine.SetState<Discharge>();
        }
    }
}