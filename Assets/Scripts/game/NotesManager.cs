using UnityEngine;
using UnityEngine.UI;

namespace game
{
    public class NotesManager : MonoBehaviour
    {
        public GameObject _notesArea, _noteSmall, _noteWide, _noteBorder;

        private bool isGenerating;

        private void Awake()
        {
            //判定線オブジェクトのAudioSource取得
            GameParameters.JudgeLineSpeaker = GameObject.Find("judgeLine").GetComponent<AudioSource>();

            // オブジェクトの取得
             ViewOperator.FindViews();

            // パラメータをViewで表示
            ViewOperator.SetParametersToView();
            
            // パラメータ代入 TODO:デバッグ用
            GameParameters.Bpm = 240;
            GameParameters.Max = 2;
            GameParameters.Min = 1;
            GameParameters.PhraseLength = 8;
            GameParameters.RefreshRate = 4;
            GameParameters.Speed = 5;
            GameParameters.NoteLength = 4;
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
        }
    }
}