using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System;
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
            GameParameters.Min = 0;
            GameParameters.Num = 8;
            GameParameters.Repeat = 4;
            GameParameters.Speed = 4;
            GameParameters.NoteLength = 4;
            
            //初期化関数を回す
            Lf.GameStartingInit();

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