using Scripts.Camera;
using Scripts.Character;
using Scripts.Logic;
using Scripts.Sound;
using UnityEngine;

namespace Scripts.Trap
{
    public class ScratchTrap : MonoBehaviour
    {
        [SerializeField] private int _subtractedTime;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite _activatedSprite;

        private SoundPlayer _soundPlayer;
        private EndGameTimer _endGameTimer;
        private CameraShaker _cameraShaker;
        private bool IsDischarged;

        public void Init(SoundPlayer soundPlayer, EndGameTimer endGameTimer, CameraShaker cameraShaker)
        {
            _soundPlayer = soundPlayer;
            _endGameTimer = endGameTimer;
            _cameraShaker = cameraShaker;
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (IsDischarged)
                return;

            if (collider.TryGetComponent(out Player _))
            {
                _soundPlayer.PlayTrapClip();
                _cameraShaker.Shake();
                _ = _endGameTimer.TrySubtract(_subtractedTime);
                _spriteRenderer.sprite = _activatedSprite;
                IsDischarged = true;
            }
        }
    }
}