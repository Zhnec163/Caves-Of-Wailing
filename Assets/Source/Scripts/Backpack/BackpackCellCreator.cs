using UnityEngine;

public class BackpackCellCreator : MonoBehaviour
{
    [SerializeField] private BackpackCell _prefab;

    public BackpackCell Create(Vector3 position, Transform parent) =>
         Instantiate(_prefab, position, parent.rotation, parent);
}
