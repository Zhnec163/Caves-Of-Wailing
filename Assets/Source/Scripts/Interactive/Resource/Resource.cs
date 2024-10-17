using System;
using UnityEngine;

namespace Scripts.Interactive.Resource
{
    [RequireComponent(typeof(ResourceMover))]
    public class Resource : MonoBehaviour
    {
        private ResourceMover _resourceMover;
        private Transform _portal;

        public event Action<Resource> Delivered;

        public void Init(Transform portal)
        {
            _resourceMover = GetComponent<ResourceMover>();
            _portal = portal;
        }

        public void MoveToPortal()
        {
            _resourceMover.MoveEnded += OnMoveEnded;
            _resourceMover.MoveTo(_portal);
        }

        public void MoveToBackpack(Transform backpackCell) =>
            _resourceMover.MoveTo(backpackCell);

        private void OnMoveEnded()
        {
            _resourceMover.MoveEnded -= OnMoveEnded;
            Delivered?.Invoke(this);
        }
    }
}