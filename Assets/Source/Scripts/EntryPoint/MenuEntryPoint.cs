using Scripts.Constant;
using Scripts.Sound;
using UnityEngine;

namespace Scripts.EntryPoint
{
    public class MenuEntryPoint : MonoBehaviour
    {
        [SerializeField] private MixerChannelChanger _music;
        [SerializeField] private MixerChannelChanger _sound;

        private void Start()
        {
            _music.Init(PlayerPrefNames.MusicMixerChannel);
            _sound.Init(PlayerPrefNames.SoundMixerChannel);
        }
    }
}