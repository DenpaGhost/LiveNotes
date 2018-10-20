using System;
using System.Diagnostics;
using UnityEngine;
using Lf = game.LiveNotesFunctions;

namespace game
{
    public class Note : MonoBehaviour
    {
        public long TargetTime { private get; set; }
        public Stopwatch Timer { private get; set; }
        public int Lane { private get; set; }
        public Action GetButtonDownFunction { get; set; }
        
        private GameConstants.Judge _myJudge = GameConstants.Judge.Miss;

        // Update is called once per frame
        private void Update ()
        {
            //描画される位置を計算
            var position = NotesOperator.CalcSpawnPosition(Timer.ElapsedTicks, TargetTime);
            //配置
            gameObject.GetComponent<RectTransform>().localPosition = new Vector2(gameObject.GetComponent<RectTransform>().localPosition.x, GameConstants.JUDGE_LINE_Y + position);

            //ボタン
            JudgeByButtonInput();
            
            //目標タイムを越したら...
            if (TargetTime < Timer.ElapsedTicks)
            {
                IsPassedTargetTime();
            }
			
        }

        private void IsPassedTargetTime()
        {
            //線上で待機
            if (TargetTime + GameConstants.NOTE_IS_ON_LINE_WAIT_TIME <= Timer.ElapsedTicks)
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.GetComponent<RectTransform>().localPosition = new Vector2(gameObject.GetComponent<RectTransform>().localPosition.x, GameConstants.JUDGE_LINE_Y);
            }
        }

        private void JudgeByButtonInput()
        {
            if (GameParameters.LaneQueue[Lane][0] == gameObject && Input.GetButtonDown(GameConstants.KEY_NAME[Lane]))
            {

                if (TargetTime + GameConstants.JUDGE_PERFECT >= Timer.ElapsedTicks && TargetTime - GameConstants.JUDGE_PERFECT <= Timer.ElapsedTicks)
                {
                    LiveNotesFunctions.SetJudgeText("Perfect!!!");
                    _myJudge = GameConstants.Judge.Perfect;
                    Destroy(gameObject);
                }
                else if (TargetTime + GameConstants.JUDGE_GREAT >= Timer.ElapsedTicks && TargetTime - GameConstants.JUDGE_GREAT <= Timer.ElapsedTicks)
                {
                    LiveNotesFunctions.SetJudgeText("Great!!");
                    _myJudge = GameConstants.Judge.Great;
                    Destroy(gameObject);
                } 
                else if (TargetTime + GameConstants.JUDGE_GOOD >= Timer.ElapsedTicks && TargetTime - GameConstants.JUDGE_GOOD <= Timer.ElapsedTicks)
                {
                    LiveNotesFunctions.SetJudgeText("Good!");
                    _myJudge = GameConstants.Judge.Good;
                    Destroy(gameObject);
                } 
                else if (TargetTime + GameConstants.JUDGE_MISS >= Timer.ElapsedTicks && TargetTime - GameConstants.JUDGE_MISS <= Timer.ElapsedTicks)
                {
                    LiveNotesFunctions.SetJudgeText("Miss...");
                    Destroy(gameObject);
                }
                
            }
        }

        private void OnDestroy()
        {
            switch (_myJudge)
            {
                case GameConstants.Judge.Perfect:
                    GameParameters.Perfect+=1;
                    break;
                
                case GameConstants.Judge.Great :
                    GameParameters.Great+=1;
                    break;
                
                case GameConstants.Judge.Good:
                    GameParameters.Good+=1;
                    break;
                
                default:
                    GameParameters.Miss+=1;
                    break;        
            }

            GameParameters.NotesCount += 1;
            
            LiveNotesFunctions.SetJudgeCount(_myJudge);
            GameParameters.LaneQueue[Lane].RemoveAt(0);
        }
    }
    
}