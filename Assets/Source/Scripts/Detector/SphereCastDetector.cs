using UnityEngine;

namespace Scripts.Detector
{
    public abstract class SphereCastDetector : MonoBehaviour
    {
        [SerializeField] private float _distance;
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _layerMask;

        protected float Distance => _distance;
        protected float Radius => _radius;
        protected LayerMask LayerMask => _layerMask;

        protected abstract void Detecting();
    }
}