using System;
using Agava.WebUtility;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    //TODO декомпозировать
    [SerializeField] private SoundPlayer _soundPlayer;
    [SerializeField] private Portal _portal;
    [SerializeField] private EndGameTimer _endGameTimer;
    [SerializeField] private ExperienceBalance _experienceBalance;
    [SerializeField] private MenuController _menuController;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _toMenuButton;

    public event Action Paused;
    public event Action Unpaused;

    private void OnEnable()
    {
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChangeEvent;
        _endGameTimer.Ended += OnEnded;
        _portal.Builded += OnBuilded;
        _pauseButton.onClick.AddListener(OnClickPauseButton);
        _resumeButton.onClick.AddListener(OnClickResumeButton);
        _toMenuButton.onClick.AddListener(OnClickToMenuButton);
    }

    private void OnDestroy()
    {
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChangeEvent;
        _endGameTimer.Ended -= OnEnded;
        _portal.Builded -= OnBuilded;
        _pauseButton.onClick.RemoveListener(OnClickPauseButton);
        _resumeButton.onClick.RemoveListener(OnClickResumeButton);
        _toMenuButton.onClick.RemoveListener(OnClickToMenuButton);
    }

    private void OnInBackgroundChangeEvent(bool isInBackground)
    {
        if (isInBackground)
            Pause();
        else
            Unpause();
    }

    private void OnClickToMenuButton()
    {
        Unpause();
        SceneManager.LoadScene(SceneNames.Menu);
    }

    private void OnClickPauseButton()
    {
        Pause();
        _menuController.OpenPauseMenu();
    }

    private void OnClickResumeButton()
    {
        Unpause();
        _menuController.HidePauseMenu();
    }

    private void OnBuilded()
    {
        _soundPlayer.PlayWinClip();
        Pause();

        int score = _experienceBalance.TotalBalance * _endGameTimer.Time;

        if (PlayerPrefs.HasKey(PlayerPrefNames.BestScore))
        {
            int bestScore = PlayerPrefs.GetInt(PlayerPrefNames.BestScore);

            if (bestScore < score)
                PlayerPrefs.SetInt(PlayerPrefNames.BestScore, score);
        }
        else
        {
            PlayerPrefs.SetInt(PlayerPrefNames.BestScore, score);
        }
                
        _menuController.OpenWinnerMenu(_experienceBalance.TotalBalance, _endGameTimer.Time, score);
    }

    private void OnEnded()
    {
        _soundPlayer.PlayLoseClip();
        Pause();
        _menuController.OpenLoseMenu();
    }

    private void Pause()
    {
        Time.timeScale = 0F;
        Paused?.Invoke();
    }

    private void Unpause()
    {
        Time.timeScale = 1;
        Unpaused?.Invoke();
    }
}