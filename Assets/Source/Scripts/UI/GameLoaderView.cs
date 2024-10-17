using Scripts.UI.Loader;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI
{
    [RequireComponent(typeof(Image))]
    public class GameLoaderView : MonoBehaviour
    {
        [SerializeField] private GameLoader _gameLoader;

        private Image _image;

        private void Awake() =>
            _image = GetComponent<Image>();

        public void Update() =>
            _image.fillAmount = _gameLoader.Progress;
    }
}