using UiButtons.Title.module;
using UnityEngine;

namespace game
{
    public class GameManager : MonoBehaviour
    {
        public GameObject 
            eventSystem,
            settingCard;

        public AudioClip defaultClip;

        private void Start()
        {
            ViewOperator.SetParametersToView();
            for (var i = 0; i < GameParameters.KeySounds.Length; i++)
            {
                GameParameters.KeySounds[i] = defaultClip;
                GameParameters.KeySounds[i].LoadAudioData();
            }
        }

        public void OnClick()
        {
            eventSystem.GetComponent<NotesManager>().enabled = true;
            settingCard.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                eventSystem.GetComponent<NotesManager>().enabled = false;
                settingCard.SetActive(true);
            }
        }
    }
}