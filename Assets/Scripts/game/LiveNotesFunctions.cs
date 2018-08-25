using System.Collections.Generic;
using UnityEngine;
using Constants;

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

        //最初にリストをいっぱいにするための関数
        public static List<NotesData> FirstPushNotesDataToList()
        {
            var list = new List<NotesData>();
            while (list.Count < GameConstants.MIN_NOTES_COUNT)
            {
                var tmp = Generate(GameParameters.Num,GameParameters.Max,GameParameters.Min);

                for (var repeat = 0; repeat < GameParameters.Repeat; repeat++)
                {
                    for (var i = 0; i < tmp.Length; i++)
                    {
                        list.Add(new NotesData(tmp[i],
                            GameParameters.Interval * i + GameConstants.WAIT_FOR_START_TIME));
                    }
                }
                
            }

            return list;
        }
        
        //ノーツ生成時の初期位置を計算する関数
        public static double CalcuSpawnPosition(long nowTime, long targetTime)
        {
            var y = nowTime / targetTime * GameConstants.NOTES_AREA_HEIGHT * GameParameters.Speed;

            return y;
        }
        
    }
}