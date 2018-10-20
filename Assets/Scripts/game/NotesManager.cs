using UnityEngine;
using UnityEngine.UI;

namespace game
{
    public class NotesManager : MonoBehaviour
    {
        public GameObject _notesArea, _noteSmall, _noteWide, _noteBorder, fpsView;

        private void Awake()
        {
            //判定線オブジェクトのAudioSource取得
            GameParameters.JudgeLineSpeaker = GameObject.Find("judgeLine").GetComponent<AudioSource>();

            // オブジェクトの取得
             ViewOperator.FindViews();

            // パラメータをViewで表示
            ViewOperator.SetParametersToView();
        }

        private void OnEnable()
        {
            //初期化関数を回す
            ViewOperator.GameStartingInit();

            //最初のノーツを出す
            NotesOperator.SpawnNote(GameParameters.NotesList, _notesArea, _noteWide, _noteSmall, _noteBorder);
        }

        private void OnDisable()
        {
            GameParameters.NotesList.Clear();
            
        }

        // Update is called once per frame
        private void Update()
        {
            NotesOperator.SpawnNote(GameParameters.NotesList, _notesArea, _noteWide, _noteSmall, _noteBorder);

            fpsView.GetComponent<Text>().text = UtilFunctions.ShowFps();
        }
    }
}