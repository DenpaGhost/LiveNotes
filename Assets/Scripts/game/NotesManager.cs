using UnityEngine;
using UnityEngine.UI;
using Lf = game.LiveNotesFunctions;

namespace game
{
    public class NotesManager : MonoBehaviour
    {
        public GameObject _notesArea, _noteSmall, _noteWide, _noteBorder, fpsView;

        private void OnEnable()
        {
            // パラメータ代入 TODO:デバッグ用
            GameParameters.Bpm = 240;
            GameParameters.Max = 3;
            GameParameters.Min = 0;
            GameParameters.Num = 8;
            GameParameters.Repeat = 4;
            GameParameters.Speed = 5;
            GameParameters.NoteLength = 4;

            //初期化関数を回す
            LiveNotesFunctions.GameStartingInit();

            //最初のノーツを出す
            LiveNotesFunctions.SpawnNote(GameParameters.NotesList, _notesArea, _noteWide, _noteSmall, _noteBorder);
        }

        private void OnDisable()
        {
            GameParameters.NotesList.Clear();
            
        }

        // Update is called once per frame
        private void Update()
        {
            LiveNotesFunctions.SpawnNote(GameParameters.NotesList, _notesArea, _noteWide, _noteSmall, _noteBorder);

            fpsView.GetComponent<Text>().text = UtilFunctions.ShowFps();
        }
    }
}