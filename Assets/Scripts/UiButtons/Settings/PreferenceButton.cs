using UnityEngine;

namespace UiButtons.Title.Settings
{
    public class PreferenceButton : BaseSettingsButton
    {
        public override void ClickEvent()
        {
            Debug.Log("プリファレンス設定へ");
        }
    }
}