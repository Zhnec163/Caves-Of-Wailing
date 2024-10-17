using UnityEngine;

namespace Scripts.Input
{
    public class JoystickInputSource : InputSource
    {
        [SerializeField] private VariableJoystick _variableJoystick;

        public override Vector2 GetDirection() =>
            _variableJoystick.Direction;
    }
}