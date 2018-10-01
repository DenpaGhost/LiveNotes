using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Game
{
    public class LiveNotesFunctions : MonoBehaviour
    {
        //フレーズを作る関数
        public static int[] Generate(ushort num, byte max, byte min)
        {

            //ノーツデータ用配列初期化
            var notes = new int[num];
            
            //必要な個数ノーツ生成
            for (var i = 0; i < notes.Length; i++)
            {

                //出現ノーツ数を乱数で決める
                var each = Random.Range(min, max+1);
			
                //ノーツ位置データ
                byte[] tmp = {1, 2, 4, 8, 16, 32, 64};
			
                //出現数だけ繰り返す
                for (var j = 0; j < each; j++)
                {
                    //どこに出すか決める
                    var task = (byte) Random.Range(0, 7-j);
				
                    //代入
                    notes[i] = notes[i] | tmp[task];
                    				
                    //重複しないように後ろにあるのを持ってくる
                    tmp[task] = tmp[tmp.Length-(j+1)];

                }

            }

            return notes;

        }
        
        //リストをいっぱいにするための関数
        public static List<NotesData> PushNotesDataToList(List<NotesData> list)
        {   
            //targetTimeをずらすためのカウンタ
            var counter = 0;
            
            //それぞれのノーツが参照するタイマーの設定
            var timer = new Stopwatch();
            timer.Start();

            //オフセット
            long offset;
            if (list.Count == 0)
            {
                offset = GameConstants.DEFAULT_OFFSET;
            }
            else
            {
                //画面に残っているノーツの数を取得
                var drawNotesCount = GameObject.FindGameObjectsWithTag("Border").Length;
                
                //まだリストに残ってる分 + 画面内にいる分
                offset = (list.Count + drawNotesCount) * GameParameters.Interval;
            }
            
            //超えるまで作る
            while (list.Count <= GameParameters.MinListCount)
            {
                var phrase = Generate(GameParameters.Num, GameParameters.Max, GameParameters.Min);

                for (var repeat = 0; repeat < GameParameters.Repeat; repeat++)
                {
                    foreach (var note in phrase)
                    {
                        var targetTime = GameParameters.Interval * counter + offset;
                        list.Add(new NotesData(note, targetTime, timer));
                        counter ++;
                    }
                }
            }
            
            return list;
        }
        
        //ノーツ生成時の初期位置を計算する関数
        public static float CalcSpawnPosition(long nowTime, long targetTime)
        {
            var y = (targetTime - nowTime) / 100000f * GameParameters.Speed;

            return y;
        }
        
        //スコア計算関数
        public static ulong CalcScore()
        {
            return GameParameters.Perfect * GameConstants.SCORE_PERFECT +
                   GameParameters.Great * GameConstants.SCORE_GREAT +
                   GameParameters.Good * GameConstants.SCORE_GOOD;
        }

        //キューを読み出してGameObjectを生成する関数
        public static void SpawnNote(List<NotesData> notesList, GameObject notesArea, GameObject noteWide,
            GameObject noteSmall,GameObject noteBorder)
        {
            while (true)
            {
                //値を受け取る
                var targetTime = notesList[0].TargetTime;
                var timer = notesList[0].Timer;

                //描画されるであろう位置を計算
                var spawnPosition = CalcSpawnPosition(timer.ElapsedTicks, targetTime);

                //画面外でなければ描画
                if (GameConstants.NOTES_AREA_HEIGHT > spawnPosition)
                {
                    //ボーダー生成
                    var border = Instantiate(noteBorder);
                    border.GetComponent<Border>().TargetTime = targetTime;
                    border.GetComponent<Border>().Timer = timer;
                    border.GetComponent<Transform>().SetParent(notesArea.GetComponent<Transform>());
                    border.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    border.GetComponent<RectTransform>().localPosition = new Vector2(border.GetComponent<RectTransform>().localPosition.x,GameConstants.JUDGE_LINE_Y +  spawnPosition);
                    border.GetComponent<RectTransform>().offsetMin = noteBorder.GetComponent<RectTransform>().offsetMin;
                    border.GetComponent<RectTransform>().offsetMax = noteBorder.GetComponent<RectTransform>().offsetMax;
                    
                    var lanesPosition = notesList[0].LanesPosition;

                    for (var i = 0; i < GameConstants.POSITION_DATA.Length; i++)
                    {
                        if ((lanesPosition & GameConstants.POSITION_DATA[i]) == GameConstants.POSITION_DATA[i])
                        {
                            GameObject note;
                            if (i % 2 == 0)
                            {
                                note = Instantiate(noteWide);
                            }
                            else
                            {
                                note = Instantiate(noteSmall);
                            }

                            //ノーツ生成
                            note.transform.SetParent(notesArea.GetComponent<Transform>());
                            note.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                            note.GetComponent<RectTransform>().localPosition = new Vector2(GameConstants.LANE_POSITION_DATA_X[i],GameConstants.JUDGE_LINE_Y +  spawnPosition);
                            note.GetComponent<Note>().TargetTime = targetTime;
                            note.GetComponent<Note>().Timer = timer;
                            note.GetComponent<Note>().Lane = i;

                            //キューに追加
                            GameParameters.LaneQueue[i].Add(note);

                        }
                    }
                    
                    //先頭を削除
                    notesList.RemoveAt(0);
                }
                else
                {
                    return;
                }
            }
        }

        //デバッグ用。判定表示。
        public static void SetJudgeText(string text)
        {
            GameParameters.JudgeTextObject.GetComponent<Text>().text = text;
            GameParameters.JudgeTextObject.GetComponent<JudgeTextManager>().stopwatch.Stop();
            GameParameters.JudgeTextObject.GetComponent<JudgeTextManager>().stopwatch.Reset();
            GameParameters.JudgeTextObject.GetComponent<JudgeTextManager>().stopwatch.Start();
        }

        //左のあっこへ数値を反映する。
        public static void SetJudgeCount(GameConstants.Judge judge)
        {
            switch (judge)
            {
                case GameConstants.Judge.Perfect:
                    GameParameters.PerfectTextView.GetComponent<Text>().text =
                        String.Format("{0:#,0}", GameParameters.Perfect);
                    break;
                
                case GameConstants.Judge.Great:
                    GameParameters.GreatTextView.GetComponent<Text>().text =
                        String.Format("{0:#,0}", GameParameters.Great);
                    break;
                
                case GameConstants.Judge.Good:
                    GameParameters.GoodTextView.GetComponent<Text>().text=
                        String.Format("{0:#,0}", GameParameters.Good);
                    break;
                
                default:
                    GameParameters.MissTextView.GetComponent<Text>().text=
                        String.Format("{0:#,0}", GameParameters.Miss);
                    break;
            }

            var score = CalcScore();
            GameParameters.ScoreTextView.GetComponent<Text>().text=String.Format("{0:#,0}", score);
            
        }

        //パラメータ初期化系のやつ
        public static void GameStartingInit()
        {
            //ノーツキュー初期化
            for (var i = 0; i < GameParameters.LaneQueue.Length; i++)
            {
                GameParameters.LaneQueue[i] = new List<GameObject>();
            }
            
            //判定線オブジェクトのAudioSource取得
            GameParameters.JudgeLineSpeaker = GameObject.Find("judgeLine").GetComponent<AudioSource>();

            // オブジェクトの取得
            FindViews();

            // パラメータをViewで表示
            SetParametersToView();
            
            //刻み数計算
            GameParameters.Interval = 600000000 / GameParameters.Bpm;

            //Listに詰めこむ
            GameParameters.NotesList = new List<NotesData>();
            GameParameters.NotesList = PushNotesDataToList(GameParameters.NotesList);
            
            //リストの最低必要個数を計算
            GameParameters.MinListCount = GameParameters.NotesList.Count;
        }

        private static void FindViews()
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

        private static void SetParametersToView()
        {
            GameObject.Find("ComposerValue").GetComponent<Text>().text =
                "Debug";
            
            GameObject.Find("BPMValue").GetComponent<Text>().text = 
                UtilFunctions.PutComma(GameParameters.Bpm);
            
            GameObject.Find("MultipleValue").GetComponent<Text>().text =
                GameParameters.Max + " : " + GameParameters.Min;
            
            GameObject.Find("PhraseValue").GetComponent<Text>().text = 
                UtilFunctions.PutComma(GameParameters.Num);
            
            GameObject.Find("RefreshRateValue").GetComponent<Text>().text =
                UtilFunctions.PutComma(GameParameters.Repeat);
            
            GameObject.Find("NoteLengthValue").GetComponent<Text>().text = 
                "4";

            RefreshSpeedView();

        }

        public static void RefreshSpeedView()
        {
            GameParameters.SpeedTextView.GetComponent<Text>().text =
                GameParameters.Speed.ToString();
        }
        
    }
}