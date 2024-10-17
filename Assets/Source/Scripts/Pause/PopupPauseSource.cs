namespace Scripts.Pause
{
    public class PopupPauseSource : PauseSource
    {
        private void OnEnable() =>
            Activate();

        private void OnDisable() =>
            Deactivate();
    }
}