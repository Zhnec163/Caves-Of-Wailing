using System.Collections.Generic;
using Scripts.Camera;
using Scripts.Character;
using Scripts.Creator;
using Scripts.Improvement;
using Scripts.Input;
using Scripts.InteractiveZone;
using Scripts.Logic;
using Scripts.Pause;
using Scripts.Sound;
using Scripts.UI;
using UnityEngine;
using YG;

namespace Scripts.EntryPoint
{
    public class GameEntryPoint : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private GameLogic _gameLogic;
        [SerializeField] private PauseController _pauseController;
        [SerializeField] private UserInterfaceController _userInterfaceController;
        [SerializeField] private Reward _reward;
        [SerializeField] private ExperienceBalance _experienceBalance;
        [SerializeField] private ResourceSpawner _resourceSpawner;
        [SerializeField] private CameraShaker _cameraShaker;
        [SerializeField] private SoundPlayer _soundPlayer;
        [SerializeField] private EndGameTimer _endGameTimer;
        [SerializeField] private Portal _portal;
        [SerializeField] private UpgradeZone _upgradeZone;
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private KeyboardInputSource _keyboardInputSource;
        [SerializeField] private JoystickInputSource _joystickInputSource;
        [SerializeField] private List<Upgrade> _upgrades;
        [SerializeField] private List<PauseSource> _pauseSources;
        [SerializeField] private List<RoomBuilder> _roomConfigurators;

        private void Awake()
        {
            if (YandexGame.EnvironmentData.isMobile || YandexGame.EnvironmentData.isTablet)
            {
                _joystickInputSource.gameObject.SetActive(true);
                _inputReader.Init(_joystickInputSource);
            }
            else
            {
                _inputReader.Init(_keyboardInputSource);
            }

            _player.Init(_inputReader, _soundPlayer);
            _gameLogic.Init(_portal, _endGameTimer, _experienceBalance, _soundPlayer, _reward);
            _portal.Init(_resourceSpawner);
            _roomConfigurators.ForEach(roomConfigurator =>
                roomConfigurator.Init(_soundPlayer, _endGameTimer, _cameraShaker, _resourceSpawner));
            _upgrades.ForEach(upgrade => upgrade.Init(_soundPlayer, _experienceBalance));
            _pauseController.Init(_gameLogic, _pauseSources);
            _userInterfaceController.Init(_upgradeZone, _gameLogic);
            _resourceSpawner.Init(_portal);
        }
    }
}