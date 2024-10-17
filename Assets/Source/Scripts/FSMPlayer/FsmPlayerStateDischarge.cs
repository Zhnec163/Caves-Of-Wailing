using System.Threading;
using Cysharp.Threading.Tasks;
using Scripts.Character;
using Scripts.Input;

namespace Scripts.FSMPlayer
{
    public class FsmPlayerStateDischarge : FsmPlayerState
    {
        private readonly Backpack _backpack;
        private readonly float _dischargeTime;
        private UniTask _discharging;
        private CancellationTokenSource _cancellationTokenSource;

        public FsmPlayerStateDischarge(
            FsmPlayer fsmPlayer,
            PlayerAnimator playerAnimator,
            InputReader inputReader,
            Backpack backpack,
            float dischargeTime)
            : base(fsmPlayer, playerAnimator, inputReader)
        {
            _backpack = backpack;
            _dischargeTime = dischargeTime;
        }

        public override void Enter()
        {
            PlayerAnimator.PlayIdleAnimation();
            _cancellationTokenSource = new();
            _discharging = Discharging();
        }

        public override void Exit() =>
            _cancellationTokenSource.Cancel();

        public override void Update()
        {
            if (InputReader.HaveInput())
                FsmPlayer.SetState<FsmPlayerStateRun>();
            else if (_backpack.IsEmpty())
                FsmPlayer.SetState<FsmPlayerStateIdle>();
            else if (_discharging.Status == UniTaskStatus.Succeeded)
                _discharging = Discharging();
        }

        private async UniTask Discharging()
        {
            await UniTask.WaitForSeconds(_dischargeTime, false, PlayerLoopTiming.Update, _cancellationTokenSource.Token);

            if (_cancellationTokenSource.IsCancellationRequested)
                return;

            _ = _backpack.TryDischarge();
        }
    }
}