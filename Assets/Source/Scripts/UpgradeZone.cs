using UnityEngine;

public class UpgradeZone : MonoBehaviour
{
    [SerializeField] private MenuController _menuController;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Player _))
            _menuController.ShowUpgrade();
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent(out Player _))
            _menuController.CloseUpgrade();
    }
}
