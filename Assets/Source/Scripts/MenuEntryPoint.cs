using Agava.YandexGames;
using UnityEngine;

public class MenuEntryPoint : MonoBehaviour
{
    [SerializeField] private MixerChannelChanger _music; 
    [SerializeField] private MixerChannelChanger _sound;

    private void Start()
    {
        //TODO доработать точку входа
#if UNITY_WEBGL && !UNITY_EDITOR
        YandexGamesSdk.GameReady();
#endif
        _music.Init(PlayerPrefNames.MusicMixerChannel);
        _sound.Init(PlayerPrefNames.SoundMixerChannel);
    }
}
