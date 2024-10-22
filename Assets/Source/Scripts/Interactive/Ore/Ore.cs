using Scripts.Creator;
using UnityEngine;

namespace Scripts.Interactive.Ore
{
    [RequireComponent(typeof(OreMeshChanger))]
    public class Ore : MonoBehaviour
    {
        [SerializeField] private int _resourceAmount;

        private ResourceSpawner _resourceSpawner;
        private OreMeshChanger _oreMeshChanger;

        public void Init(ResourceSpawner resourceSpawner)
        {
            _oreMeshChanger = GetComponent<OreMeshChanger>();
            _resourceSpawner = resourceSpawner;
        }

        private void Update()
        {
            if (IsEmpty())
                Destroy(gameObject);
        }

        public bool TryGetResource(out Resource.Resource resource)
        {
            resource = default;

            if (IsEmpty())
                return false;

            resource = _resourceSpawner.Spawn(transform.position);
            _resourceAmount--;
            _oreMeshChanger.ChangeModel();
            return true;
        }

        public bool IsNotEmpty() =>
            _resourceAmount > 0;

        public bool IsEmpty() =>
            _resourceAmount == 0;
    }
}