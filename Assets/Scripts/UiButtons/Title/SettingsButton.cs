using UnityEngine;

namespace UiButtons.Title
{
    public class SettingsButton : BaseTitleButton
    {
        public override void Select()
        {
            base.Select();
            CanvasAnimator.SetTrigger(UiConstants.SETTING_HIGHLIGHT_TRIGGER);
        }

        public override void ClickEvent()
        {
            Debug.Log("設定画面を起動する処理");
        }
    }
}