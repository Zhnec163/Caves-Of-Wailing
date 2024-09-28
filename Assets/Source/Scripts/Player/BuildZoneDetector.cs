using UnityEngine;

public class BuildZoneDetector : MonoBehaviour
{
    public bool IsInner { get; private set; }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out BuildZone _))
            IsInner = true;
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent(out BuildZone _))
            IsInner = false;
    }
}
