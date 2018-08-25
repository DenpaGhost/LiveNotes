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

        private List<NotesData> _notesList;

        public GameObject _notesArea, _noteSmall, _noteWide;

        // Use this for initialization
        public void Start()
        {
            // パラメータ代入 TODO:デバッグ用
            GameParameters.Bpm = 120;
            GameParameters.Max = 1;
            GameParameters.Min = 1;
            GameParameters.Num = 20;
            GameParameters.Repeat = 1;
            GameParameters.Speed = 5;
            
            //刻み数計算
            GameParameters.Interval = 600000000 / GameParameters.Bpm;
            
            //リストの最低必要個数を計算
            GameParameters.MinListCount = (GameParameters.MinListCount / GameParameters.Num + 1) * GameParameters.Num;

            //Listに詰めこむ
            _notesList = new List<NotesData>();
            _notesList = Lf.PushNotesDataToList(_notesList);

            for (int i = 0; i < _notesList.Count; i++)
            {
                Debug.Log("Lane : " + _notesList[i].LanesPosition +"\ntargetTime : " + _notesList[i].TargetTime);
            }
            
            //最初のノーツを出す
            Lf.SpawnNote(_notesList,_notesArea,_noteWide,_noteSmall);

        }

        // Update is called once per frame
        public void Update()
        {
            
            if (_notesList.Count < GameParameters.MinListCount)
            {
                Debug.Log("aaaaa");
                _notesList = Lf.PushNotesDataToList(_notesList);
            }
            
            Lf.SpawnNote(_notesList,_notesArea,_noteWide,_noteSmall);
            
        }

    }
}