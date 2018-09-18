using UnityEngine;

namespace UiButtons.Title
{
    public class QuickButton : BaseUiButton
    {
        public override void Select()
        {
            base.Select();
            CanvasAnimator.SetTrigger(UiConstants.QUICK_HIGHLIGHT_TRIGGER);
        }

        public override void ClickEvent()
        {
            // TODO:そのうち
            Debug.Log("Quickモードで起動する処理");
        }
    }
}