using Lean.Localization;
using UnityEngine;
using YG;

namespace Scripts.Localization
{
    public class Localization : MonoBehaviour
    {
        private const string EnglishCode = "English";
        private const string RussianCode = "Russian";
        private const string TurkishCode = "Turkish";
        private const string English = "en";
        private const string Russian = "ru";
        private const string Turkish = "tr";

        [SerializeField] private LeanLocalization _leanLanguage;

        private void Awake() =>
            ChangeLanguage(YandexGame.savesData.language);

        private void OnEnable() =>
            YandexGame.SwitchLangEvent += ChangeLanguage;

        private void OnDisable() =>
            YandexGame.SwitchLangEvent -= ChangeLanguage;

        private void ChangeLanguage(string language)
        {
            switch (language)
            {
                case English:
                    _leanLanguage.SetCurrentLanguage(EnglishCode);
                    break;
                case Turkish:
                    _leanLanguage.SetCurrentLanguage(TurkishCode);
                    break;
                case Russian:
                    _leanLanguage.SetCurrentLanguage(RussianCode);
                    break;
            }
        }
    }
}