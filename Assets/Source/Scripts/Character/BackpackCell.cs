using Scripts.Interactive.Resource;
using UnityEngine;

namespace Scripts.Character
{
    public class BackpackCell : MonoBehaviour
    {
        private Resource _resource;

        public bool TryPut(Resource resource)
        {
            if (IsNotEmpty())
                return false;

            _resource = resource;
            _resource.transform.parent = transform;
            return true;
        }

        public bool TryGetResource(out Resource resource)
        {
            resource = default;

            if (IsEmpty())
                return false;

            resource = _resource;
            resource.transform.parent = default;
            _resource = default;
            return true;
        }

        public bool HaveResource() =>
            _resource != default;

        public bool IsEmpty() =>
            _resource == default;

        private bool IsNotEmpty() =>
            _resource != default;
    }
}