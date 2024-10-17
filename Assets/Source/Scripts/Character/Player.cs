using Scripts.Detector;
using Scripts.FSMPlayer;
using Scripts.Input;
using Scripts.Sound;
using UnityEngine;

namespace Scripts.Character
{
    [RequireComponent(typeof(PlayerMover)), RequireComponent(typeof(PlayerAnimator)), RequireComponent(typeof(ExperienceBalance))]
    [RequireComponent(typeof(BuildZoneDetector)), RequireComponent(typeof(PlayerAnimationEventHandler))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _collectTime;
        [SerializeField] private float _dischargeTime;
        [SerializeField] private Backpack _backpack;
        [SerializeField] private OreDetector _oreDetector;

        private FsmPlayer _fsmPlayer;

        public void Init(InputReader inputReader, SoundPlayer soundPlayer)
        {
            GetComponent<PlayerAnimationEventHandler>().Init(soundPlayer);

            PlayerMover playerMover = GetComponent<PlayerMover>();
            PlayerAnimator playerAnimator = GetComponent<PlayerAnimator>();
            BuildZoneDetector buildZoneDetector = GetComponent<BuildZoneDetector>();
            ExperienceBalance experienceBalance = GetComponent<ExperienceBalance>();

            _fsmPlayer = new FsmPlayer();

            FsmPlayerStateCreator playerStateCreator = new FsmPlayerStateCreator(
                _fsmPlayer,
                playerAnimator,
                inputReader,
                _backpack,
                _oreDetector);

            _fsmPlayer.AddState(playerStateCreator.CreateStateIdle(buildZoneDetector));
            _fsmPlayer.AddState(playerStateCreator.CreateStateRun(playerMover));
            _fsmPlayer.AddState(playerStateCreator.CreateStateCollect(_collectTime, experienceBalance));
            _fsmPlayer.AddState(playerStateCreator.CreateStateDischarge(_dischargeTime));
        }

        private void Start() =>
            _fsmPlayer.SetState<FsmPlayerStateIdle>();

        private void Update() =>
            _fsmPlayer.Update();

        private void FixedUpdate() =>
            _fsmPlayer.FixedUpdate();
    }
}