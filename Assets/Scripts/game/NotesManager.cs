using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Constants;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Lf = Game.LiveNotesFunctions;

namespace Game
{
    public class NotesManager : MonoBehaviour
    {

        public GameObject _notesArea, _noteSmall, _noteWide, _noteBorder;

        // Use this for initialization
        public void Start()
        {
            // パラメータ代入 TODO:デバッグ用
            GameParameters.Bpm = 360;
            GameParameters.Max = 1;
            GameParameters.Min = 1;
            GameParameters.Num = 20;
            GameParameters.Repeat = 8;
            GameParameters.Speed = 3;
            GameParameters.NoteLength = 4;
            
            //ノーツキュー初期化
            for (int i = 0; i < GameParameters.LaneQueue.Length; i++)
            {
                GameParameters.LaneQueue[i] = new List<GameObject>();
            }
            
            //判定線オブジェクトのAudioSource取得
            GameParameters.JudgeLineSpeaker = GameObject.Find("judgeLine").GetComponent<AudioSource>();
            
            //刻み数計算
            GameParameters.Interval = 600000000 / GameParameters.Bpm;

            //Listに詰めこむ
            GameParameters.NotesList = new List<NotesData>();
            GameParameters.NotesList = Lf.PushNotesDataToList(GameParameters.NotesList);
            
            //リストの最低必要個数を計算
            GameParameters.MinListCount = GameParameters.NotesList.Count;

            //最初のノーツを出す
            Lf.SpawnNote(GameParameters.NotesList, _notesArea, _noteWide, _noteSmall, _noteBorder);

        }

        // Update is called once per frame
        public void Update()
        {
            Lf.SpawnNote(GameParameters.NotesList, _notesArea, _noteWide, _noteSmall, _noteBorder);
        }

    }
}