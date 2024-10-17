using Scripts.Interactive.Ore;
using UnityEngine;

namespace Scripts.Detector
{
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

        protected override void Detecting()
        {
            if (Physics.SphereCast(transform.position, Radius, transform.forward, out RaycastHit raycastHit, Distance, LayerMask))
            {
                if (raycastHit.collider.TryGetComponent(out Ore ore))
                    _ore = ore;
            }
            else
            {
                _ore = default;
            }
        }
    }
}