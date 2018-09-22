using UnityEngine;

namespace UiButtons.Title.Settings
{
    public abstract class BaseSettingsButton : BaseUiButton
    {
        public override void Select()
        {
            AudioSource.Stop();
            AudioSource.PlayOneShot(AudioSource.clip);
            gameObject.GetComponent<Animator>().SetTrigger(DialogTriggerConstants.SELECTED);
        }
        
        public void Deselected()
        {
            gameObject.GetComponent<Animator>().SetTrigger(DialogTriggerConstants.NORMAL);
        }
    }
}