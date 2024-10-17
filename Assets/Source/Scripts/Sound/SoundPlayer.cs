using UnityEngine;

namespace Scripts.Sound
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField] private AudioClip _collect;
        [SerializeField] private AudioClip _upgrade;
        [SerializeField] private AudioClip _trap;
        [SerializeField] private AudioClip _win;
        [SerializeField] private AudioClip _lose;

        private AudioSource _soundSource;

        private void Awake() =>
            _soundSource = GetComponent<AudioSource>();

        public void PlayCollectClip() =>
            _soundSource.PlayOneShot(_collect);

        public void PlayTrapClip() =>
            _soundSource.PlayOneShot(_trap);

        public void PlayLoseClip() =>
            _soundSource.PlayOneShot(_lose);

        public void PlayWinClip() =>
            _soundSource.PlayOneShot(_win);

        public void PlayUpgradeClip() =>
            _soundSource.PlayOneShot(_upgrade);
    }
}