namespace UiButtons.Title
{
    public abstract class BaseTitleButton : BaseUiButton
    {
        public override void Select()
        {
            AudioSource.Stop();
            AudioSource.PlayOneShot(AudioSource.clip);
            
            CanvasAnimator.ResetTrigger(UiConstants.QUICK_HIGHLIGHT_TRIGGER);
            CanvasAnimator.ResetTrigger(UiConstants.ARTIST_HIGHLIGHT_TRIGGER);
            CanvasAnimator.ResetTrigger(UiConstants.SETTING_HIGHLIGHT_TRIGGER);
            CanvasAnimator.ResetTrigger(UiConstants.EXIT_HIGHLIGHT_TRIGGER);

        }
    }
}