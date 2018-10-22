using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace game
{
    public class ViewOperator : MonoBehaviour
    {
        //パラメータ初期化系のやつ
        public static void GameStartingInit()
        {
            //ノーツキュー初期化
            for (var i = 0; i < GameParameters.LaneQueue.Length; i++)
            {
                GameParameters.LaneQueue[i] = new List<GameObject>();
            }

            //刻み数計算
            GameParameters.Interval = 600000000 / GameParameters.Bpm;

            //Listに詰めこむ
            GameParameters.NotesList = new List<NotesData>();
            NotesOperator.PushNotesDataToList(GameParameters.NotesList, ComposerPlain.GetInstance());

            //リストの最低必要個数を計算
            GameParameters.MinListCount = GameParameters.NotesList.Count;
        }

        public static void FindViews()
        {
            //判定表示UI Textの初期化
            GameParameters.JudgeTextObject = GameObject.Find("JudgeText");

            //左側の数字出すとこのオブジェクト取得
            GameParameters.ScoreTextView = GameObject.Find("scoreValue");
            GameParameters.PerfectTextView = GameObject.Find("perfectValue");
            GameParameters.GreatTextView = GameObject.Find("greatValue");
            GameParameters.GoodTextView = GameObject.Find("goodValue");
            GameParameters.MissTextView = GameObject.Find("missValue");
            GameParameters.SpeedTextView = GameObject.Find("speedValue");
        }

        public static void SetParametersToView()
        {
            GameObject.Find("ComposerValue").GetComponent<Text>().text =
                "Debug";

            GameObject.Find("BPMValue").GetComponent<Text>().text =
                UtilFunctions.PutComma(GameParameters.Bpm);

            GameObject.Find("MultipleValue").GetComponent<Text>().text =
                GameParameters.Max + " : " + GameParameters.Min;

            GameObject.Find("PhraseValue").GetComponent<Text>().text =
                UtilFunctions.PutComma(GameParameters.PhraseLength);

            GameObject.Find("RefreshRateValue").GetComponent<Text>().text =
                UtilFunctions.PutComma(GameParameters.RefreshRate);

            GameObject.Find("NoteLengthValue").GetComponent<Text>().text =
                "4";

            RefreshSpeedView();
        }

        public static void RefreshSpeedView()
        {
            GameParameters.SpeedTextView.GetComponent<Text>().text =
                GameParameters.Speed.ToString();
        }

        //EventSystemへ選択されているオブジェクトを指定する
        public static void SetCurrentSelect(GameObject targetObject)
        {
            EventSystem.current.SetSelectedGameObject(targetObject);
        }
    }
}