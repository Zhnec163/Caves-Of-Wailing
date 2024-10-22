using Scripts.Detector;
using Scripts.Improvement;
using UnityEngine;

namespace Scripts.Character
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(SurfaceSlider))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _speedForUpgrade;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private Upgrade _upgrade;
        [SerializeField] private WallDetector _wallDetector;

        private Rigidbody _rigidbody;
        private SurfaceSlider _surfaceSlider;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _surfaceSlider = GetComponent<SurfaceSlider>();
            _upgrade.Upgraded += OnUpgraded;
        }

        private void OnDestroy() =>
            _upgrade.Upgraded -= OnUpgraded;

        public void Move(Vector2 direction)
        {
            Rotate(direction);

            if (_wallDetector.IsNearWall)
                return;

            Vector3 normalizedDirection = new Vector3(direction.x, 0, direction.y).normalized;
            Vector3 offset = _surfaceSlider.Project(normalizedDirection) * (_moveSpeed * Time.fixedDeltaTime);
            _rigidbody.MovePosition(_rigidbody.position + offset);
        }

        private void Rotate(Vector2 direction)
        {
            Quaternion targetRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.y));
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.fixedDeltaTime * _rotateSpeed);
        }

        private void OnUpgraded() =>
            _moveSpeed += _speedForUpgrade;
    }
}