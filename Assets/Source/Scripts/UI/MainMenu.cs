using Agava.YandexGames;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GameLoader))]
public class MainMenu : MonoBehaviour
{
    //TODO навести порядок
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _leaderboardButton;
    [SerializeField] private Button _backButton;
    [SerializeField] private GameObject _settingsMenu;
    [SerializeField] private Button _authorizationConfirmationButton;
    [SerializeField] private Button _authorizationDeniedButton;
    [SerializeField] private GameObject _authorizationPopup;
    [SerializeField] private YandexLeaderboard _yandexLeaderboard;

    private GameLoader _gameLoader;

    private void Awake()
    {
        _gameLoader = GetComponent<GameLoader>();
        _playButton.onClick.AddListener(OnClickPlayButton);
        _settingsButton.onClick.AddListener(OnClickSettingButton);
        _leaderboardButton.onClick.AddListener(OnClickLeaderboardButton);
        _backButton.onClick.AddListener(OnClickBackButton);
        _authorizationConfirmationButton.onClick.AddListener(OnClickAuthorizationConfirmationButton);
        _authorizationDeniedButton.onClick.AddListener(OnClickAuthorizationDeniedButton);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnClickPlayButton);
        _settingsButton.onClick.RemoveListener(OnClickSettingButton);
        _leaderboardButton.onClick.RemoveListener(OnClickLeaderboardButton);
        _backButton.onClick.RemoveListener(OnClickBackButton);
        _authorizationConfirmationButton.onClick.RemoveListener(OnClickAuthorizationConfirmationButton);
        _authorizationDeniedButton.onClick.RemoveListener(OnClickAuthorizationDeniedButton);
    }

    private void OnClickPlayButton()
    {
        //TODO Добавить пропуск в подземелье
        _gameLoader.Load(SceneNames.Level);
    }

    private void OnClickSettingButton()
    {
        _playButton.gameObject.SetActive(false);
        _settingsButton.gameObject.SetActive(false);
        _leaderboardButton.gameObject.SetActive(false);
        _settingsMenu.SetActive(true);
    }

    private void OnClickLeaderboardButton()
    {
        if (PlayerAccount.IsAuthorized)
            PlayerAccount.RequestPersonalProfileDataPermission(OnSuccessCallback);
        else
            ShowAuthorizationPopup();
    }

    private void OnSuccessCallback()
    {
        //TODO добавть отрисовку лидерборда
    }

    private void OnClickAuthorizationConfirmationButton()
    {
        PlayerAccount.Authorize();
        CloseAuthorizationPopup();
    }

    private void OnClickAuthorizationDeniedButton() =>
        CloseAuthorizationPopup();

    private void OnClickBackButton()
    {
        _playButton.gameObject.SetActive(true);
        _settingsButton.gameObject.SetActive(true);
        _leaderboardButton.gameObject.SetActive(true);
        _settingsMenu.SetActive(false);
    }

    private void ShowAuthorizationPopup() =>
        _authorizationPopup.SetActive(true);

    private void CloseAuthorizationPopup() =>
        _authorizationPopup.SetActive(false);
}