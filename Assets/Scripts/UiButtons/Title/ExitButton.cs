using UnityEngine.EventSystems;

namespace UiButtons.Title
{
    public class ExitButton : BaseUiButton
    {
        public override void Select()
        {
            base.Select();
            CanvasAnimator.SetTrigger(UiConstants.EXIT_HIGHLIGHT_TRIGGER);
        }
        
        public override void ClickEvent()
        {
            EventSystem.current.SetSelectedGameObject(null);
            CanvasAnimator.SetTrigger(UiConstants.EXIT_DIALOG_SHOW_TRIGGER);
        }
    }
}