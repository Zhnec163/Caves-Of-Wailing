using UnityEngine;

public class KeyboardInputSource : InputSource
{
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
    }

    private void OnDisable() =>
        _playerInput.Disable();

    public override Vector2 GetDirection() =>
        _playerInput.Player.Move.ReadValue<Vector2>();
}
