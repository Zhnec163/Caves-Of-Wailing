using Scripts.Constant;
using UnityEngine;
using UnityEngine.UI;
using YG;
using YG.Utils.LB;

namespace Scripts.LeaderBoard
{
    [RequireComponent(typeof(LeaderboardYG))]
    public class YandexLeaderboard : MonoBehaviour
    {
        [SerializeField] private Button _leaderboardButton;
        [SerializeField] private GameObject _leaderboardView;
        [SerializeField] private GameObject _authorizationPopup;
        [SerializeField] private Button _authorizationConfirmationButton;
        [SerializeField] private Button _authorizationDeniedButton;

        private bool _isActive;

        private void Awake()
        {
            _leaderboardButton.onClick.AddListener(OnClickLeaderboardButton);
            _authorizationConfirmationButton.onClick.AddListener(OnClickAuthorizationConfirmationButton);
            _authorizationDeniedButton.onClick.AddListener(OnClickAuthorizationDeniedButton);
            YandexGame.onGetLeaderboard += OnGetLeaderboard;
        }

        private void OnDestroy()
        {
            YandexGame.onGetLeaderboard -= OnGetLeaderboard;
            _leaderboardButton.onClick.RemoveListener(OnClickLeaderboardButton);
            _authorizationConfirmationButton.onClick.RemoveListener(OnClickAuthorizationConfirmationButton);
            _authorizationDeniedButton.onClick.RemoveListener(OnClickAuthorizationDeniedButton);
        }

        private void OnGetLeaderboard(LBData lbData) =>
            PlayerPrefs.SetInt(PlayerPrefNames.BestScore, lbData.thisPlayer.score);

        private void OnClickLeaderboardButton()
        {
            if (_isActive)
            {
                _isActive = false;
                CloseLeaderboardView();
            }
            else
            {
                if (YandexGame.auth)
                {
                    _isActive = true;
                    ShowLeaderboardView();
                }
                else
                {
                    ShowAuthorizationPopup();
                }
            }
        }

        private void OnClickAuthorizationConfirmationButton()
        {
            YandexGame.AuthDialog();
            CloseAuthorizationPopup();
        }

        private void OnClickAuthorizationDeniedButton() =>
            CloseAuthorizationPopup();

        private void ShowAuthorizationPopup() =>
            _authorizationPopup.SetActive(true);

        private void CloseAuthorizationPopup() =>
            _authorizationPopup.SetActive(false);

        private void ShowLeaderboardView() =>
            _leaderboardView.SetActive(true);

        private void CloseLeaderboardView() =>
            _leaderboardView.SetActive(false);
    }
}