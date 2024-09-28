using System;
using UnityEngine;

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
    
    private void OnDisable() =>
        _resourceMover.MoveEnded -= OnMoveEnded;

    public void MoveToPortal()
    {
        _resourceMover.MoveEnded += OnMoveEnded;
        _resourceMover.MoveTo(_portal);
    }

    public void MoveToBackpack(Transform backpackCell) =>
        _resourceMover.MoveTo(backpackCell);

    private void OnMoveEnded() =>
        Delivered?.Invoke(this);
}
