using Agava.WebUtility;
using UnityEngine;

namespace Scripts.Pause
{
    public class FocusPauseSource : PauseSource
    {
        private void Awake()
        {
            Application.focusChanged += OnInBackgroundChangeApp;
            WebApplication.InBackgroundChangeEvent += OnInBackgroundChangeWeb;
        }

        private void OnDestroy()
        {
            Application.focusChanged -= OnInBackgroundChangeApp;
            WebApplication.InBackgroundChangeEvent -= OnInBackgroundChangeWeb;
        }

        private void OnInBackgroundChangeApp(bool inApp) =>
            ChangeActiveState(!inApp);

        private void OnInBackgroundChangeWeb(bool isBackground) =>
            ChangeActiveState(isBackground);

        private void ChangeActiveState(bool isActive)
        {
            if (isActive)
                Activate();
            else
                Deactivate();
        }
    }
}