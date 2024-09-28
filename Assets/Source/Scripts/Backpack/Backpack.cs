using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BackpackCellCreator))]
public class Backpack : MonoBehaviour
{
    private readonly List<BackpackCell> _cells = new();

    [SerializeField] private int _defaultCapacity; 
    [SerializeField] private float _capacityForUpgrade;
    [SerializeField] private float _offsetCell;
    [SerializeField]private Upgrade _upgrade;

    private BackpackCellCreator _backpackCellCreator;

    public event Action<int, int> Updated;

    public int DefaultCapacity => _defaultCapacity;

    private void Awake()
    {
        _backpackCellCreator = GetComponent<BackpackCellCreator>();
        
        for (int i = 0; i < _defaultCapacity; i++)
        {
            Vector3 position = transform.position + Vector3.up * _offsetCell * i;
            _cells.Add(_backpackCellCreator.Create(position, transform));
        }
        
        _upgrade.Upgraded += OnUpgraded;
    }

    private void OnDisable() =>
        _upgrade.Upgraded -= OnUpgraded;

    public bool TryDischarge() 
    {
        if (HaveResources())
        {
            BackpackCell backpackCell = _cells.LastOrDefault(cell => cell.HaveResource());

            if (backpackCell != default && backpackCell.TryGetResource(out Resource resource))
            {
                resource.MoveToPortal();
                Updated?.Invoke(ResourceCount(), _cells.Count);
                return true;
            }
        }

        return false;
    }
    
    public bool TryPutResource(Resource resource)
    {
        if (IsNotFull())
        {
            BackpackCell backpackCell = _cells.FirstOrDefault(cell => cell.IsEmpty());

            if (backpackCell != default && backpackCell.TryPut(resource))
            {
                resource.MoveToBackpack(backpackCell.transform);
                Updated?.Invoke(ResourceCount(), _cells.Count);
                return true;
            }
        }

        return false;
    }

    public bool IsEmpty() =>
        _cells.All(cell => cell.IsEmpty());

    public bool IsNotFull() =>
        _cells.Any(cell => cell.IsEmpty());

    public bool IsFull() =>
        _cells.All(cell => cell.HaveResource());

    public bool HaveResources() =>
        _cells.Any(cell => cell.HaveResource());

    private int ResourceCount() =>
        _cells.Count(cell => cell.HaveResource());
    
    private void OnUpgraded()
    {
        BackpackCell lastCell = _cells.LastOrDefault();

        if (lastCell == default)
            return;

        for (int i = 1; i <= _capacityForUpgrade; i++)
        {
            Vector3 position = lastCell.transform.position + Vector3.up * _offsetCell * i;
            _cells.Add(_backpackCellCreator.Create(position, transform));
        }
        
        Updated?.Invoke(ResourceCount(), _cells.Count);
    }
}