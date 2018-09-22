using UnityEngine;

namespace UiButtons.Title
{
    public class ArtistButton : BaseTitleButton
    {
        public override void Select()
        {
            base.Select();
            CanvasAnimator.SetTrigger(UiConstants.ARTIST_HIGHLIGHT_TRIGGER);
        }

        public override void ClickEvent()
        {
            Debug.Log("Artistモードで起動する処理");
        }
    }
}