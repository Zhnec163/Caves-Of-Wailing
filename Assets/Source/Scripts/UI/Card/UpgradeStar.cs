using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI.Card
{
    [RequireComponent(typeof(Image))]
    public class UpgradeStar : MonoBehaviour
    {
        [SerializeField] private Sprite _fill;

        private Image _image;

        public bool IsFilled { get; private set; }

        private void Awake() =>
            _image = GetComponent<Image>();

        public bool TryFill()
        {
            if (IsFilled)
                return false;

            _image.sprite = _fill;
            IsFilled = true;
            return true;
        }
    }
}