using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private GameLogic _gameLogic;

    private InputSource _inputSource;
    private bool _isReading;

    public Vector2 Input { get; private set; }

    public void Init(InputSource inputSource)
    {
        _inputSource = inputSource;
        _gameLogic.Paused += OnPaused;
        _gameLogic.Unpaused += OnUnpaused;
        _isReading = true;
    }

    private void OnDisable()
    {
        _gameLogic.Paused -= OnPaused;
        _gameLogic.Unpaused -= OnUnpaused;
    }

    private void Update()
    {
        if (_isReading)
            Input = _inputSource.GetDirection();
    }

    private void OnUnpaused() =>
        _isReading = true;

    private void OnPaused() =>
        _isReading = false;

    public bool HaveInput() =>
        Input != Vector2.zero;

    public bool NotHaveInput() =>
        Input == Vector2.zero;
}