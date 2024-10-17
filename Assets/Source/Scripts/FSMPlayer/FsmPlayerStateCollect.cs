using System.Threading;
using Cysharp.Threading.Tasks;
using Scripts.Character;
using Scripts.Detector;
using Scripts.Input;
using Scripts.Interactive.Ore;
using Scripts.Interactive.Resource;

namespace Scripts.FSMPlayer
{
    public class FsmPlayerStateCollect : FsmPlayerState
    {
        private readonly OreDetector _oreDetector;
        private readonly Backpack _backpack;
        private readonly ExperienceBalance _experienceBalance;
        private readonly float _collectTime;
        private UniTask _collecting;
        private CancellationTokenSource _cancellationTokenSource;

        public FsmPlayerStateCollect(
            FsmPlayer fsmPlayer,
            PlayerAnimator playerAnimator,
            InputReader inputReader,
            OreDetector oreDetector,
            Backpack backpack,
            float collectTime,
            ExperienceBalance experienceBalance)
            : base(fsmPlayer, playerAnimator, inputReader)
        {
            _oreDetector = oreDetector;
            _backpack = backpack;
            _collectTime = collectTime;
            _experienceBalance = experienceBalance;
        }

        public override void Enter()
        {
            PlayerAnimator.PlayCollectAnimation();
            _cancellationTokenSource = new();
            _collecting = Collecting();
        }

        public override void Exit() =>
            _cancellationTokenSource?.Cancel();

        public override void Update()
        {
            if (InputReader.HaveInput())
                FsmPlayer.SetState<FsmPlayerStateRun>();
            else if (_oreDetector.TryGetOre(out Ore _) == false || _oreDetector.TryGetOre(out Ore ore) && ore.IsEmpty() || _backpack.IsFull())
                FsmPlayer.SetState<FsmPlayerStateIdle>();
            else if (_collecting.Status == UniTaskStatus.Succeeded)
                _collecting = Collecting();
        }

        private async UniTask Collecting()
        {
            await UniTask.WaitForSeconds(_collectTime, false, PlayerLoopTiming.Update, _cancellationTokenSource.Token);

            if (_cancellationTokenSource.IsCancellationRequested)
                return;

            if (_oreDetector.TryGetOre(out Ore ore) && ore.TryGetResource(out Resource resource))
            {
                if (_backpack.TryPutResource(resource))
                    _experienceBalance.Increment();
            }
        }
    }
}