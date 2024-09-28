using UnityEngine;

public class Ore : MonoBehaviour
{
    [SerializeField] private ResourceSpawner _resourceSpawner;
    [SerializeField] private int _resourceAmount;

    public bool TryGetResource(out Resource resource)
    {
        resource = default;
        
        if (IsNotEmpty())
        {
            resource = _resourceSpawner.Spawn(transform.position);
            _resourceAmount--;
            
            if (IsEmpty())
                Destroy(gameObject); // TODO убрать
            
            return true;
        }

        return false;
    }

    public bool IsNotEmpty() =>
        _resourceAmount > 0;
    
    public bool IsEmpty() =>
        _resourceAmount == 0;
}