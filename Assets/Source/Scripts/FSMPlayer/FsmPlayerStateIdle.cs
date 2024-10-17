using Scripts.Character;
using Scripts.Detector;
using Scripts.Input;
using Scripts.Interactive.Ore;

namespace Scripts.FSMPlayer
{
    public class FsmPlayerStateIdle : FsmPlayerState
    {
        private readonly OreDetector _oreDetector;
        private readonly BuildZoneDetector _buildZoneDetector;
        private readonly Backpack _backpack;

        public FsmPlayerStateIdle(
            FsmPlayer fsmPlayer,
            PlayerAnimator playerAnimator,
            InputReader inputReader,
            OreDetector oreDetector,
            Backpack backpack,
            BuildZoneDetector buildZoneDetector)
            : base(fsmPlayer, playerAnimator, inputReader)
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
                FsmPlayer.SetState<FsmPlayerStateRun>();
            else if (_oreDetector.TryGetOre(out Ore ore) && ore.IsNotEmpty() && _backpack.IsNotFull())
                FsmPlayer.SetState<FsmPlayerStateCollect>();
            else if (_buildZoneDetector.IsInner && _backpack.HaveResources())
                FsmPlayer.SetState<FsmPlayerStateDischarge>();
        }
    }
}