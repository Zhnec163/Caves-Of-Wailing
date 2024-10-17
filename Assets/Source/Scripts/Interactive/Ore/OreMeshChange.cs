using UnityEngine;

namespace Scripts.Interactive.Ore
{
    [RequireComponent(typeof(MeshFilter))]
    public class OreMeshChange : MonoBehaviour
    {
        [SerializeField] private Mesh _smallOre;

        private MeshFilter _meshFilter;

        private void Awake() =>
            _meshFilter = GetComponent<MeshFilter>();

        public void ChangeModel() =>
            _meshFilter.mesh = _smallOre;
    }
}