using Scripts.Creator;
using UnityEngine;

namespace Scripts.Interactive.Ore
{
    [RequireComponent(typeof(OreMeshChange))]
    public class Ore : MonoBehaviour
    {
        [SerializeField] private int _resourceAmount;

        private ResourceSpawner _resourceSpawner;
        private OreMeshChange _oreMeshChange;

        public void Init(ResourceSpawner resourceSpawner)
        {
            _oreMeshChange = GetComponent<OreMeshChange>();
            _resourceSpawner = resourceSpawner;
        }

        public bool TryGetResource(out Resource.Resource resource)
        {
            resource = default;

            if (IsNotEmpty())
            {
                resource = _resourceSpawner.Spawn(transform.position);
                _resourceAmount--;
                _oreMeshChange.ChangeModel();

                if (IsEmpty())
                    Destroy(gameObject);

                return true;
            }

            return false;
        }

        public bool IsNotEmpty() =>
            _resourceAmount > 0;

        public bool IsEmpty() =>
            _resourceAmount == 0;
    }
}