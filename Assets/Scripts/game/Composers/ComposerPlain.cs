using UnityEngine;

namespace game
{
    public class ComposerPlain : BaseComposer
    {
        private static readonly ComposerPlain composerInstance = new ComposerPlain();

        private ComposerPlain()
        {
        }

        public static ComposerPlain GetInstance()
        {
            return composerInstance;
        }
        
        public override int[] GeneratePhrase(ushort length, byte max, byte min)
        {
            //ノーツデータ用配列初期化
            var notes = new int[length];
            
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
    }
}