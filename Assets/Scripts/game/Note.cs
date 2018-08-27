using System;
using System.Diagnostics;
using UnityEngine;
using Lf = Game.LiveNotesFunctions;
using Constants;
using Debug = UnityEngine.Debug;

namespace Game
{
    public class Note : MonoBehaviour
    {
        public long TargetTime { private get; set; }
        public Stopwatch Timer { private get; set; }
	
        // Update is called once per frame
        private void Update ()
        {
            //描画される位置を計算
            var position = Lf.CalcuSpawnPosition(Timer.ElapsedTicks, TargetTime);
			
            //配置
            gameObject.GetComponent<RectTransform>().localPosition = new Vector2(gameObject.GetComponent<RectTransform>().localPosition.x, GameConstants.JUDGE_LINE_Y + position);

            //目標タイムを越したら...
            if (TargetTime < Timer.ElapsedTicks)
            {
                //0.5秒は線上で待機
                if (TargetTime + 5000000 < Timer.ElapsedTicks)
                {
                    Destroy(gameObject);
                }
                else
                {
                    gameObject.GetComponent<RectTransform>().localPosition = new Vector2(gameObject.GetComponent<RectTransform>().localPosition.x, GameConstants.JUDGE_LINE_Y);
                }
            }
			
        }
    }
}