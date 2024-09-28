using UnityEngine;

public abstract class SphereCastDetector : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Color _color;

    protected float Distance => _distance;
    protected float Radius => _radius;
    protected LayerMask LayerMask => _layerMask;

    protected abstract void Detecting();

    private void OnDrawGizmos()
    {
        Gizmos.color = _color;
        Gizmos.DrawSphere(transform.position + transform.forward * _distance, _radius);
    }
}
