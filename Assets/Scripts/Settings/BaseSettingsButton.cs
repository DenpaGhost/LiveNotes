using UnityEngine;
using UnityEngine.UI;

namespace UiButtons.Title.Settings
{
    public class BaseSettingsButton : BaseUiButton
    {
        public SettingManager Manager;
        public GameObject TargetContent;
        
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

        public void AllContentInvisible()
        {
            Manager.OutputContent.SetActive(false);
            Manager.PreferenceContent.SetActive(false);
            Manager.OverviewContent.SetActive(false);
        }

        public void AllButtonToNormal()
        {
            Manager.OutputButton.GetComponent<Image>().color = ConstantsColors.SETTINGS_BUTTON_NORMAL;
            Manager.PreferenceButton.GetComponent<Image>().color = ConstantsColors.SETTINGS_BUTTON_NORMAL;
            Manager.OverviewButton.GetComponent<Image>().color = ConstantsColors.SETTINGS_BUTTON_NORMAL;
        }

        public void ButtonToVisiting()
        {
            gameObject.GetComponent<Image>().color = ConstantsColors.SETTINGS_BUTTON_HIGHLIGHT;
        }

        public void ShowContent()
        {
            TargetContent.SetActive(true);
        }
        
        public override void ClickEvent()
        {
            AllContentInvisible();
            AllButtonToNormal();

            ShowContent();
            ButtonToVisiting();
        }

    }
}