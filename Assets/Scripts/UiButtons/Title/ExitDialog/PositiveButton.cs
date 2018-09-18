using UnityEngine;

namespace UiButtons.Title.ExitDialog
{
    public class PositiveButton : BaseDialogButton
    {
        public override void ClickEvent()
        {
            Application.Quit();
        }
    }
}