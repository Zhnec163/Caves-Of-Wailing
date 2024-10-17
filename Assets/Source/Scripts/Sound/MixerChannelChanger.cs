using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Scripts.Sound
{
    [RequireComponent(typeof(Slider))]
    public class MixerChannelChanger : MonoBehaviour
    {
        private const int _logarithmFactor = 20;

        [SerializeField] private AudioMixer _mixer;

        private string _paramName;
        private Slider _slider;

        public void Init(string paramName)
        {
            _paramName = paramName;
            _slider = GetComponent<Slider>();

            if (PlayerPrefs.HasKey(_paramName))
                _slider.value = PlayerPrefs.GetFloat(_paramName);

            _slider.onValueChanged.AddListener(OnValueChange);
            _mixer.SetFloat(_paramName, Mathf.Log10(_slider.value) * _logarithmFactor);
        }

        private void OnDestroy() =>
            _slider.onValueChanged.RemoveListener(OnValueChange);

        private void OnValueChange(float value)
        {
            _mixer.SetFloat(_paramName, Mathf.Log10(value) * _logarithmFactor);
            PlayerPrefs.SetFloat(_paramName, value);
        }
    }
}