using System.Collections;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class YandexSDKInitializer : MonoBehaviour
{
    private void Awake() =>
        YandexGamesSdk.CallbackLogging = true;

    private IEnumerator Start() =>
        YandexGamesSdk.Initialize(OnInitialized);

    private void OnInitialized() =>
        SceneManager.LoadScene(SceneNames.Menu);
}
