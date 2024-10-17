using UnityEngine;

namespace Scripts.Input
{
    public class InputReader : MonoBehaviour
    {
        private InputSource _inputSource;

        public Vector2 Input { get; private set; }

        public void Init(InputSource inputSource) =>
            _inputSource = inputSource;

        private void Update() =>
            Input = _inputSource.GetDirection();

        public bool HaveInput() =>
            Input != Vector2.zero;

        public bool NotHaveInput() =>
            Input == Vector2.zero;
    }
}