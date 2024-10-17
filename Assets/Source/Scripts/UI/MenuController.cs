using Scripts.Constant;
using Scripts.UI.Entity;
using Scripts.UI.Loader;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI
{
    [RequireComponent(typeof(GameLoader))]
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _backButton;
        [SerializeField] private SettingsMenu _settingsMenu;

        private GameLoader _gameLoader;

        private void Awake()
        {
            _gameLoader = GetComponent<GameLoader>();
            _playButton.onClick.AddListener(OnClickPlayButton);
            _settingsButton.onClick.AddListener(OnClickSettingButton);
            _backButton.onClick.AddListener(OnClickBackButton);
        }

        private void OnDestroy()
        {
            _playButton.onClick.RemoveListener(OnClickPlayButton);
            _settingsButton.onClick.RemoveListener(OnClickSettingButton);
            _backButton.onClick.RemoveListener(OnClickBackButton);
        }

        private void OnClickPlayButton() =>
            _gameLoader.Load(SceneNames.Level);

        private void OnClickSettingButton()
        {
            ClosePlayButton();
            CloseSettingsButton();
            ShowSettingsMenu();
        }

        private void OnClickBackButton()
        {
            ShowPlayButton();
            ShowSettingsButton();
            CloseSettingsMenu();
        }

        private void ShowSettingsMenu() =>
            _settingsMenu.gameObject.SetActive(true);

        private void CloseSettingsMenu() =>
            _settingsMenu.gameObject.SetActive(false);

        private void ShowSettingsButton() =>
            _settingsButton.gameObject.SetActive(true);

        private void CloseSettingsButton() =>
            _settingsButton.gameObject.SetActive(false);

        private void ShowPlayButton() =>
            _playButton.gameObject.SetActive(true);

        private void ClosePlayButton() =>
            _playButton.gameObject.SetActive(false);
    }
}