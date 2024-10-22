using System.Collections;
using Scripts.Detector;
using Scripts.FSMPlayer;
using Scripts.FSMPlayer.States;
using Scripts.Input;
using Scripts.Sound;
using UnityEngine;

namespace Scripts.Character
{
    [RequireComponent(typeof(PlayerMover))]
    [RequireComponent(typeof(PlayerAnimator))]
    [RequireComponent(typeof(ExperienceBalance))]
    [RequireComponent(typeof(BuildZoneDetector))]
    [RequireComponent(typeof(PlayerAnimationEventHandler))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _collectTime;
        [SerializeField] private float _dischargeTime;
        [SerializeField] private Backpack _backpack;
        [SerializeField] private OreDetector _oreDetector;

        private StateMachine _stateMachine;

        public void Init(InputReader inputReader, SoundPlayer soundPlayer)
        {
            GetComponent<PlayerAnimationEventHandler>().Init(soundPlayer);

            PlayerMover playerMover = GetComponent<PlayerMover>();
            PlayerAnimator playerAnimator = GetComponent<PlayerAnimator>();
            BuildZoneDetector buildZoneDetector = GetComponent<BuildZoneDetector>();
            ExperienceBalance experienceBalance = GetComponent<ExperienceBalance>();

            _stateMachine = new StateMachine();

            StateCreator stateCreator = new StateCreator(
                _stateMachine,
                playerAnimator,
                inputReader,
                _backpack,
                _oreDetector);

            _stateMachine.AddState(stateCreator.CreateStateIdle(buildZoneDetector));
            _stateMachine.AddState(stateCreator.CreateStateRun(playerMover));
            _stateMachine.AddState(stateCreator.CreateStateCollect(_collectTime, experienceBalance));
            _stateMachine.AddState(stateCreator.CreateStateDischarge(_dischargeTime));
        }

        private IEnumerator Start()
        {
            yield return new WaitUntil(() => _stateMachine != null);
            _stateMachine.SetState<Idle>();
        }

        private void Update() =>
            _stateMachine.Update();

        private void FixedUpdate() =>
            _stateMachine.FixedUpdate();
    }
}