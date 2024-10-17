using Scripts.Sound;
using UnityEngine;

namespace Scripts.Character
{
    public class PlayerAnimationEventHandler : MonoBehaviour
    {
        private SoundPlayer _soundPlayer;

        public void Init(SoundPlayer soundPlayer) =>
            _soundPlayer = soundPlayer;

        private void PlayCollectSound() =>
            _soundPlayer.PlayCollectClip();
    }
}