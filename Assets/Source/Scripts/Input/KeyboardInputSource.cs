using UnityEngine;

namespace Scripts.Input
{
    public class KeyboardInputSource : InputSource
    {
        private PlayerInput _playerInput;

        private void Awake()
        {
            _playerInput = new PlayerInput();
            _playerInput.Enable();
        }

        private void OnDestroy() =>
            _playerInput.Disable();

        public override Vector2 GetDirection() =>
            _playerInput.Player.Move.ReadValue<Vector2>();
    }
}