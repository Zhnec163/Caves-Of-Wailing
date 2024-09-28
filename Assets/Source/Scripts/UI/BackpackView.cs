using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class BackpackView : MonoBehaviour
{
    [SerializeField] private Backpack _backpack;
    
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        UpdateText(0, _backpack.DefaultCapacity);
        _backpack.Updated += OnUpdated;
    }
    
    private void OnDestroy() =>
        _backpack.Updated -= OnUpdated;

    private void OnUpdated(int resourceCount, int capacity) =>
        UpdateText(resourceCount, capacity);

    private void UpdateText(int resourceCount, int capacity) =>
        _text.text = $"{resourceCount} / {capacity}";
}
