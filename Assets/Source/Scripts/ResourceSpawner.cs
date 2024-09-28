using System;
using UnityEngine;
using UnityEngine.Pool;

public class ResourceSpawner : MonoBehaviour
{
    [SerializeField] private Resource _prefab;
    [SerializeField] private Portal _portal;

    private ObjectPool<Resource> _pool;

    public event Action ResourceReturned;

    private void Awake()
    {
        _pool = new ObjectPool<Resource>(
            createFunc: OnCreate,
            actionOnGet: OnGet,
            actionOnRelease: OnRelease,
            actionOnDestroy: OnDestroying);
    }

    private Resource OnCreate()
    {
        Resource resource = Instantiate(_prefab, transform.position, Quaternion.identity);
        resource.Init(_portal.transform);
        resource.Delivered += Release;
        return resource;
    }

    private void OnGet(Resource resource) =>
        resource.gameObject.SetActive(true);

    private void OnRelease(Resource resource) =>
        resource.gameObject.SetActive(false);

    private void OnDestroying(Resource resource) =>
        resource.Delivered -= Release;

    public Resource Spawn(Vector3 position)
    {
        Resource resource = _pool.Get();
        resource.transform.position = position;
        return resource;
    }

    private void Release(Resource resource)
    {
        _pool.Release(resource);
        ResourceReturned?.Invoke();
    }
}