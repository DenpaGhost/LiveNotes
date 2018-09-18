using UnityEngine;

namespace UiButtons.Title.ExitDialog
{
    public static class ExitDialogFunctions
    {
        public static void IsSelected(AudioSource audioSource, GameObject obj)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(audioSource.clip);
            obj.GetComponent<Animator>().SetTrigger(DialogTriggerConstants.SELECTED);
        }
    }
}