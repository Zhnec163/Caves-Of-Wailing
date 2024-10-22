using System.Threading;
using Cysharp.Threading.Tasks;
using Scripts.Character;
using Scripts.Input;

namespace Scripts.FSMPlayer.States
{
    public class Discharge : BaseState
    {
        private readonly Backpack _backpack;
        private readonly float _dischargeTime;
        private UniTask _discharging;
        private CancellationTokenSource _cancellationTokenSource;

        public Discharge(
            StateMachine stateMachine,
            PlayerAnimator playerAnimator,
            InputReader inputReader,
            Backpack backpack,
            float dischargeTime)
            : base(stateMachine, playerAnimator, inputReader)
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
                StateMachine.SetState<Run>();
            else if (_backpack.IsEmpty())
                StateMachine.SetState<Idle>();
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