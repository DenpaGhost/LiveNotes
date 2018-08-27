using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Constants;
using UnityEngine.Timeline;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

namespace Game
{
    public class LiveNotesFunctions : MonoBehaviour
    {
        
        
        //フレーズを作る関数
        public static int[] Generate(ushort num,byte max,byte min)
        {

            //ノーツデータ用配列初期化
            int[] Notes = new int[num];
            
            //必要な個数ノーツ生成
            for (var i = 0; i < Notes.Length; i++)
            {

                //出現ノーツ数を乱数で決める
                var each = (byte)Random.Range(min,max+1);
			
                //ノーツ位置データ
                byte[] tmp = {1, 2, 4, 8, 16, 32, 64};
			
                //出現数だけ繰り返す
                for (var j = 0; j < each; j++)
                {
                    //どこに出すか決める
                    var task = (byte) Random.Range(0, 7-j);
				
                    //代入
                    Notes[i] |= tmp[task];
				
                    //重複しないように後ろにあるのを持ってくる
                    tmp[task] = tmp[tmp.Length-(j+1)];

                }

            }

            return Notes;

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
                var serviveNotesCount = GameObject.FindGameObjectsWithTag("Border").Length;
                
                //まだリストに残ってる分 + 画面内にいる分
                offset = (list.Count + serviveNotesCount) * GameParameters.Interval;
            }
            
            //超えるまで作る
            while (list.Count <= GameParameters.MinListCount)
            {
                var phrase = Generate(GameParameters.Num,GameParameters.Max,GameParameters.Min);

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
            
            Debug.Log(counter);
            Debug.Log((float)offset/10000000);
            return list;
        }
        
        
        
        //ノーツ生成時の初期位置を計算する関数
        public static float CalcuSpawnPosition(long nowTime, long targetTime)
        {
            var y = (targetTime - nowTime) / 100000 * GameParameters.Speed;

            return y;
        }



        public static void SpawnNote(List<NotesData> notesList, GameObject notesArea, GameObject noteWide,
            GameObject noteSmall,GameObject noteBorder)
        {
            while (true)
            {
                //値を受け取る
                var targetTime = notesList[0].TargetTime;
                var timer = notesList[0].Timer;

                //描画されるであろう位置を計算
                var spawnPosition = CalcuSpawnPosition(timer.ElapsedTicks, targetTime);

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

                    for (int i = 0; i < GameConstants.POSITION_DATA.Length; i++)
                    {
                        if ((lanesPosition | GameConstants.POSITION_DATA[i]) == GameConstants.POSITION_DATA[i])
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

                            note.transform.SetParent(notesArea.GetComponent<Transform>());
                            note.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                            note.GetComponent<RectTransform>().localPosition = new Vector2(GameConstants.LANE_POSITION_DATA_X[i],GameConstants.JUDGE_LINE_Y +  spawnPosition);
                            note.GetComponent<Note>().TargetTime = targetTime;
                            note.GetComponent<Note>().Timer = timer;

                            //先頭を削除
                            notesList.RemoveAt(0);
                            
                        }
                    }
                }
                else
                {
                    break;
                }
            }
        }

    }
}