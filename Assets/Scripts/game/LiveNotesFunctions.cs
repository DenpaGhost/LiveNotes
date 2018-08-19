using UnityEngine;

namespace game
{
    public class LiveNotesFunctions
    {
        byte[] Generate(ushort num,byte max,byte min)
        {

            //ノーツデータ用配列初期化
            byte[] Notes = new byte[num];
            
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
    }
}