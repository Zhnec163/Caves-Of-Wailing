using UnityEngine;

public class WallDetector : SphereCastDetector
{
    public bool IsNearWall { get; private set; }

    private void Update() =>
        Detecting();

    protected override void Detecting() =>
        IsNearWall = Physics.SphereCast(transform.position, Radius, transform.forward, out RaycastHit _, Distance, LayerMask);
}
