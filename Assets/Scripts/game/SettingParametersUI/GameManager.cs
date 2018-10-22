using UnityEngine;

namespace game
{
    public class GameManager : MonoBehaviour
    {
        public GameObject 
            eventSystem,
            settingCard;

        private void Start()
        {
            ViewOperator.SetParametersToView();
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