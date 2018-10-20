using UnityEngine;

namespace game
{
    public class StartButton : MonoBehaviour
    {
        public GameObject eventSystem;

        private void Start()
        {
            // パラメータ代入 TODO:デバッグ用
            GameParameters.Bpm = 240;
            GameParameters.Max = 3;
            GameParameters.Min = 0;
            GameParameters.PhraseLength = 8;
            GameParameters.RefreshRate = 4;
            GameParameters.Speed = 5;
            GameParameters.NoteLength = 4;

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