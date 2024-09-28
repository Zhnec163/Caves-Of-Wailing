using UnityEngine;

[RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(SurfaceSlider))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedForUpgrade;
    [SerializeField]private Upgrade _upgrade;
    [SerializeField] private WallDetector _wallDetector;

    private Rigidbody _rigidbody;
    private SurfaceSlider _surfaceSlider;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _surfaceSlider = GetComponent<SurfaceSlider>();
        _upgrade.Upgraded += OnUpgraded;
    }

    private void OnDisable() =>
        _upgrade.Upgraded -= OnUpgraded;

    public void Move(Vector2 direction)
    {
        Rotate(direction);

        if (_wallDetector.IsNearWall)
            return;

        Vector3 offset = _surfaceSlider.Project(new Vector3(direction.x, 0, direction.y).normalized) * (_speed * Time.deltaTime);
        _rigidbody.MovePosition(_rigidbody.position + offset);
    }

    private void Rotate(Vector2 direction)
    {
        if (direction == Vector2.zero)
            return;
        
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }
    
    private void OnUpgraded() =>
        _speed += _speedForUpgrade;
}