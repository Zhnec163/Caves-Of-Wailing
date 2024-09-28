using UnityEngine;

public class SurfaceSlider : MonoBehaviour
{
    private Vector3 _normal;

    private void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, Mathf.Infinity))
            _normal = hit.normal;
    }

    public Vector3 Project(Vector3 forward) =>
        forward - Vector3.Dot(forward, _normal) * _normal;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, transform.position + _normal * 10);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Project(transform.forward));
    }
}