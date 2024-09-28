using UnityEngine;

public class OreDetector : SphereCastDetector
{
    private Ore _ore;

    private void Update() =>
        Detecting();

    public bool TryGetOre(out Ore ore)
    {
        ore = null;

        if (_ore == default)
            return false;

        ore = _ore;
        return true;
    }

    protected override void Detecting() =>
        _ore = Physics.SphereCast(transform.position, Radius, transform.forward, out RaycastHit raycastHit, Distance, LayerMask) 
               && raycastHit.collider.TryGetComponent(out Ore ore) ? ore : default;
}