using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private List<Upgrade> _upgrades;
    [SerializeField] private AudioClip _collect;
    [SerializeField] private AudioClip _upgrade;
    [SerializeField] private AudioClip _trap;
    [SerializeField] private AudioClip _win;
    [SerializeField] private AudioClip _lose;
    
    private AudioSource _soundSource;

    private void Awake()
    {
        _soundSource = GetComponent<AudioSource>();

        foreach (Upgrade upgrade in _upgrades)
            upgrade.Upgraded += OnUpgraded;
    }

    private void OnDisable()
    {
        foreach (Upgrade upgrade in _upgrades)
            upgrade.Upgraded -= OnUpgraded;
    }

    private void OnUpgraded() =>
        PlayUpgradeClip();

    public void PlayCollectClip() =>
        _soundSource.PlayOneShot(_collect);
        
    public void PlayTrapClip() =>
        _soundSource.PlayOneShot(_trap);
    
    public void PlayWinClip() =>
        _soundSource.PlayOneShot(_win);
    
    public void PlayLoseClip() =>
        _soundSource.PlayOneShot(_lose);
    
    private void PlayUpgradeClip() =>
        _soundSource.PlayOneShot(_upgrade);
}
