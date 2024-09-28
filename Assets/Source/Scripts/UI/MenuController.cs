using TMPro;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _gameUI;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _winnerMenu;
    [SerializeField] private GameObject _loseMenu;
    [SerializeField] private GameObject _upgradeCards;
    [SerializeField] private GameObject _toMenuButton;
    [SerializeField] private TMP_Text _totalExperience;
    [SerializeField] private TMP_Text _timeLeft;
    [SerializeField] private TMP_Text _score;

    private bool _isShownCards;

    public void ShowUpgrade()
    {
        _isShownCards = true;
        _upgradeCards.SetActive(true);
    }
    
    public void CloseUpgrade()
    {
        _isShownCards = false;
        _upgradeCards.SetActive(false);;
    }
    
    public void OpenPauseMenu()
    {
        _upgradeCards.SetActive(false);
        _gameUI.SetActive(false);
        _pauseMenu.SetActive(true);
        _toMenuButton.SetActive(true);
    }
    
    public void HidePauseMenu()
    {
        _pauseMenu.SetActive(false);
        _toMenuButton.SetActive(false);

        if (_isShownCards)
            _upgradeCards.SetActive(true);

        _gameUI.SetActive(true);
    }
    
    public void OpenWinnerMenu(int experience, int timeLeft, int score)
    {
        _totalExperience.text = experience.ToString();
        _timeLeft.text = timeLeft.ToString();
        _score.text = score.ToString();
        _gameUI.SetActive(false);
        _winnerMenu.SetActive(true);
        _toMenuButton.SetActive(true);
    }
    
    public void OpenLoseMenu()
    {
        _gameUI.SetActive(false);
        _loseMenu.SetActive(true);
        _toMenuButton.SetActive(true);
    }
}
