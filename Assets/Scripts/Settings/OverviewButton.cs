using UnityEngine;

namespace UiButtons.Title.Settings
{
    public class OverviewButton : BaseSettingsButton
    {
        public override void ClickEvent()
        {
            Debug.Log("概要へつなぐ");
        }
    }
}