using UnityEngine.EventSystems;

namespace UiButtons.Title.ExitDialog
{
    public class NegativeButton : BaseDialogButton
    {
        public override void ClickEvent()
        {
            CanvasAnimator.SetTrigger("exitDialogClose");
            EventSystem.current.SetSelectedGameObject(null);
        }
    }
}