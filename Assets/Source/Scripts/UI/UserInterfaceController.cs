using Scripts.Constant;
using Scripts.InteractiveZone;
using Scripts.Logic;
using Scripts.Struct;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scripts.UI
{
    public class UserInterfaceController : MonoBehaviour
    {
        [SerializeField] private GameObject _gameUI;
        [SerializeField] private GameObject _pauseMenu;
        [SerializeField] private GameObject _winnerMenu;
        [SerializeField] private GameObject _loseMenu;
        [SerializeField] private GameObject _upgradeCards;
        [SerializeField] private GameObject _rewardPopup;
        [SerializeField] private TMP_Text _totalExperience;
        [SerializeField] private TMP_Text _timeLeft;
        [SerializeField] private TMP_Text _score;
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _toMenuButton;

        private bool _isShownCards;
        private UpgradeZone _upgradeZone;
        private GameLogic _gameLogic;

        public void Init(UpgradeZone upgradeZone, GameLogic gameLogic)
        {
            _upgradeZone = upgradeZone;
            _gameLogic = gameLogic;
            _upgradeZone.PlayerEntered += OnPlayerEntered;
            _upgradeZone.PlayerExited += OnPlayerExited;
            _gameLogic.Winned += OnWinned;
            _gameLogic.Losed += OnLosed;
            _pauseButton.onClick.AddListener(OnClickPauseButton);
            _resumeButton.onClick.AddListener(OnClickResumeButton);
            _toMenuButton.onClick.AddListener(OnClickToMenuButton);
        }

        private void OnDestroy()
        {
            _upgradeZone.PlayerEntered -= OnPlayerEntered;
            _upgradeZone.PlayerExited -= OnPlayerExited;
            _gameLogic.Winned -= OnWinned;
            _gameLogic.Losed -= OnLosed;
            _pauseButton.onClick.RemoveListener(OnClickPauseButton);
            _resumeButton.onClick.RemoveListener(OnClickResumeButton);
            _toMenuButton.onClick.RemoveListener(OnClickToMenuButton);
        }

        public void ShowRewardPopup()
        {
            _rewardPopup.gameObject.SetActive(true);
            ClosePauseButton();
        }

        public void CloseRewardPopup()
        {
            _rewardPopup.gameObject.SetActive(false);
            ShowPauseButton();
        }

        private void OnWinned(Result result)
        {
            _totalExperience.text = result.TotalExperience.ToString();
            _timeLeft.text = result.Time.ToString();
            _score.text = result.Score.ToString();

            CloseGameUI();
            ShowWinnerMenu();
            ShowToMenuButton();
            CloseUpgrade();
        }

        private void OnLosed()
        {
            CloseGameUI();
            ShowLoseMenu();
            ShowToMenuButton();
            CloseUpgrade();
        }

        private void OnPlayerEntered() =>
            ShowUpgrade();

        private void OnPlayerExited() =>
            CloseUpgrade();

        private void OnClickPauseButton()
        {
            CloseUpgradeCards();
            CloseGameUI();
            ShowPauseMenu();
            ShowToMenuButton();
        }

        private void OnClickResumeButton()
        {
            ClosePauseMenu();
            CloseToMenuButton();

            if (_isShownCards)
                ShowUpgradeCards();

            ShowGameUI();
        }

        private void OnClickToMenuButton() =>
            SceneManager.LoadScene(SceneNames.Menu);

        private void ShowPauseButton() =>
            _pauseButton.gameObject.SetActive(true);

        private void ClosePauseButton() =>
            _pauseButton.gameObject.SetActive(false);

        private void ShowToMenuButton() =>
            _toMenuButton.gameObject.SetActive(true);

        private void CloseToMenuButton() =>
            _toMenuButton.gameObject.SetActive(false);

        private void ShowUpgradeCards() =>
            _upgradeCards.SetActive(true);

        private void CloseUpgradeCards() =>
            _upgradeCards.SetActive(false);

        private void ShowLoseMenu() =>
            _loseMenu.SetActive(true);

        private void ShowWinnerMenu() =>
            _winnerMenu.SetActive(true);

        private void ShowPauseMenu() =>
            _pauseMenu.SetActive(true);

        private void ClosePauseMenu() =>
            _pauseMenu.SetActive(false);

        private void ShowGameUI() =>
            _gameUI.SetActive(true);

        private void CloseGameUI() =>
            _gameUI.SetActive(false);

        private void ShowUpgrade()
        {
            _isShownCards = true;
            ShowUpgradeCards();
        }

        private void CloseUpgrade()
        {
            _isShownCards = false;
            CloseUpgradeCards();
        }
    }
}