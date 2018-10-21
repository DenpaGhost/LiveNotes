using UnityEngine;

namespace game
{
    public class StartButton : MonoBehaviour
    {
        public GameObject eventSystem;

        private void Start()
        {
            ViewOperator.SetParametersToView();
        }

        public void OnClick()
        {
            eventSystem.GetComponent<NotesManager>().enabled = true;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                eventSystem.GetComponent<NotesManager>().enabled = false;
            }
        }
    }
}