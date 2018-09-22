using UnityEngine;

namespace UiButtons.Title.ExitDialog
{
    public abstract class BaseDialogButton : BaseUiButton
    {
        public Animator CanvasAnimator;
        
        public void Deselected()
        {
            gameObject.GetComponent<Animator>().SetTrigger(DialogTriggerConstants.NORMAL);
        }
        
        public override void Select()
        {
            AudioSource.Stop();
            AudioSource.PlayOneShot(AudioSource.clip);
            gameObject.GetComponent<Animator>().SetTrigger(DialogTriggerConstants.SELECTED);
        }
    }
}