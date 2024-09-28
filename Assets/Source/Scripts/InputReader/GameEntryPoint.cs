using Agava.WebUtility;
using UnityEngine;

public class GameEntryPoint : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private KeyboardInputSource _keyboardInputSource;
    [SerializeField] private JoystickInputSource _joystickInputSource;

    private void Awake()
    {
        // TODO Дописать точку входа
        if (Device.IsMobile)
        {
            _joystickInputSource.gameObject.SetActive(true);
            _inputReader.Init(_joystickInputSource);
        }
        else
        {
            _inputReader.Init(_keyboardInputSource);
        }
    }
}