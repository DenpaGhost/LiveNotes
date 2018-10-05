using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using Lf = Game.LiveNotesFunctions;

namespace Game
{
    public class NotesManager : MonoBehaviour
    {

        public GameObject _notesArea, _noteSmall, _noteWide, _noteBorder, fpsView;

        // Use this for initialization
        private void Start()
        {
            
            // パラメータ代入 TODO:デバッグ用
            GameParameters.Bpm = 240;
            GameParameters.Max = 2;
            GameParameters.Min = 1;
            GameParameters.Num = 8;
            GameParameters.Repeat = 4;
            GameParameters.Speed = 5;
            GameParameters.NoteLength = 4;
            
            //初期化関数を回す
            Lf.GameStartingInit();

            //最初のノーツを出す
            Lf.SpawnNote(GameParameters.NotesList, _notesArea, _noteWide, _noteSmall, _noteBorder);

        }

        // Update is called once per frame
        private void Update()
        {
            Lf.SpawnNote(GameParameters.NotesList, _notesArea, _noteWide, _noteSmall, _noteBorder);

            fpsView.GetComponent<Text>().text = UtilFunctions.ShowFps();
        }

    }
}