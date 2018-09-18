using UnityEngine;

namespace UiButtons.Title.ExitDialog
{
    public abstract class BaseDialogButton : BaseUiButton
    {
        public void Deselected()
        {
            gameObject.GetComponent<Animator>().SetTrigger(DialogTriggerConstants.NORMAL);
        }
        
        public override void Select()
        {
            ExitDialogFunctions.IsSelected(AudioSource, gameObject);
        }
    }
}