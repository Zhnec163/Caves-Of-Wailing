using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Scripts.Improvement;
using TMPro;
using UnityEngine;

namespace Scripts.UI.Card
{
    public class UpgradeView : MonoBehaviour
    {
        private const float UpscaleSpeed = 0.5F;

        [SerializeField] private Upgrade _upgrade;
        [SerializeField] private List<UpgradeStar> _stars;
        [SerializeField] private TMP_Text _costText;

        protected void Awake() =>
            UpdateCost(_upgrade.Cost.ToString());

        private void OnEnable()
        {
            transform.localScale = Vector3.zero;
            transform.DOScale(Vector3.one, UpscaleSpeed);
            _upgrade.Upgraded += OnUpgraded;
        }

        private void OnDisable() =>
            _upgrade.Upgraded -= OnUpgraded;

        private void OnUpgraded()
        {
            UpdateCost(_upgrade.IsMaxUpgrade() ? string.Empty : _upgrade.Cost.ToString());
            _ = TryFillLastStar();
        }

        private void UpdateCost(string cost) =>
            _costText.text = cost;

        private bool TryFillLastStar()
        {
            UpgradeStar upgradeStar = _stars.FirstOrDefault(star => star.IsFilled == false);

            if (upgradeStar == default)
                return false;

            if (upgradeStar.TryFill())
                return true;

            return false;
        }
    }
}