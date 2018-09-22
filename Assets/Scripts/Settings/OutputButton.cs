

using UnityEngine;

namespace UiButtons.Title.Settings
{
    public class OutputButton : BaseSettingsButton
    {
        public override void ClickEvent()
        {
            Debug.Log("出力設定へつなぐ");
        }
    }
}