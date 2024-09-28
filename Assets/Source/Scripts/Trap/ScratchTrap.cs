using UnityEngine;

public class ScratchTrap : MonoBehaviour
{
    [SerializeField] private SoundPlayer _soundPlayer;
    [SerializeField] private int _subtractedTime;
    [SerializeField] private EndGameTimer _endGameTimer;
    [SerializeField] private CameraShaker _cameraShaker;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _activatedSprite;

    private bool IsDischarged;

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
