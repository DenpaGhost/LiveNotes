using System;
using System.Collections.Generic;
using UnityEngine;
using Constants;
using UnityEngine.Timeline;
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
            long time = 0;
            var counter = 0;
            var timer = new NotesTimer();
            
            while (list.Count <= GameParameters.MinListCount)
            {
                var tmp = Generate(GameParameters.Num,GameParameters.Max,GameParameters.Min);

                for (var repeat = 0; repeat < GameParameters.Repeat; repeat++)
                {
                    for (var i = 0; i < tmp.Length; i++)
                    {
                        time = GameParameters.Interval * counter + GameParameters.OffsetTime;
                        list.Add(new NotesData(tmp[i], time, timer));
                        counter ++;
                    }
                }
                
            }

            timer.StopWatch.Start();
            
            //次回のオフセットを設定
            GameParameters.OffsetTime = time + GameParameters.Interval - GameParameters.OffsetTime;
            
            Debug.Log("Offset time : "+ (float)time/10000000 + "\nList Count : " + list.Count);
            
            return list;
        }
        
        
        
        //ノーツ生成時の初期位置を計算する関数
        public static float CalcuSpawnPosition(long nowTime, long targetTime)
        {
            var y = (targetTime - nowTime) / 100000 * GameParameters.Speed;

            return y;
        }



        public static void SpawnNote(List<NotesData> notesList, GameObject notesArea, GameObject noteWide,
            GameObject noteSmall)
        {
            while (true)
            {
                //値を受け取る
                var targetTime = notesList[0].TargetTime;
                var timer = notesList[0].Timer;

                //描画されるであろう位置を計算
                var spawnPosition = CalcuSpawnPosition(timer.StopWatch.ElapsedTicks, targetTime);

                //画面外でなければ描画
                if (GameConstants.NOTES_AREA_HEIGHT > spawnPosition)
                {
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
                            note.GetComponent<RectTransform>().localPosition = new Vector2(
                                GameConstants.LANE_POSITION_DATA_X[i],
                                GameConstants.DISPLAY_UPPER_END_Y - spawnPosition);

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