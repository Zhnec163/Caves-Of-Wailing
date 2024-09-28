using Agava.WebUtility;
using UnityEngine;

public class AudioListenerSwitcher : MonoBehaviour
{
    private void Awake() =>
         WebApplication.InBackgroundChangeEvent += OnInBackgroundChangeEvent;

    private void OnDestroy() =>
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChangeEvent;

    private void OnInBackgroundChangeEvent(bool isInBackground) =>
        AudioListener.pause = isInBackground;
}