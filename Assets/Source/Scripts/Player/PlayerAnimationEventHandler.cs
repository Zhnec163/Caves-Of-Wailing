using UnityEngine;

public class PlayerAnimationEventHandler : MonoBehaviour
{
    [SerializeField] private SoundPlayer _soundPlayer;

    public void PlayCollectSound() =>
        _soundPlayer.PlayCollectClip();
}
