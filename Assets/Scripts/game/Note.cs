using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

namespace game
{
    public class Note : MonoBehaviour
    {
        public GameObject judgeEffect;
        public bool isStopped;
        public long TargetTime { private get; set; }
        public Stopwatch Timer { private get; set; }
        public int Lane { private get; set; }
        
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
            if (TargetTime + GameConstants.JUDGE_GOOD <= Timer.ElapsedTicks)
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
                    _myJudge = GameConstants.Judge.Perfect;
                    Destroy(gameObject);
                }
                else if (TargetTime + GameConstants.JUDGE_GREAT >= Timer.ElapsedTicks && TargetTime - GameConstants.JUDGE_GREAT <= Timer.ElapsedTicks)
                {
                    _myJudge = GameConstants.Judge.Great;
                    Destroy(gameObject);
                } 
                else if (TargetTime + GameConstants.JUDGE_GOOD >= Timer.ElapsedTicks && TargetTime - GameConstants.JUDGE_GOOD <= Timer.ElapsedTicks)
                {
                    _myJudge = GameConstants.Judge.Good;
                    Destroy(gameObject);
                } 
                else if (TargetTime + GameConstants.JUDGE_MISS >= Timer.ElapsedTicks && TargetTime - GameConstants.JUDGE_MISS <= Timer.ElapsedTicks)
                {
                    Destroy(gameObject);
                }
                
            }
        }

        private void OnDestroy()
        {
            if (isStopped)
            {
                return;
            }
            
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
            
            ScoreOperator.SetJudgeCount(_myJudge);
            ScoreOperator.SetJudgeText(_myJudge);
            showJudgeEffect();
            
            GameParameters.LaneQueue[Lane].RemoveAt(0);
        }

        private void showJudgeEffect()
        {
            var effect = Instantiate(judgeEffect);
            effect.transform.SetParent(GameParameters.JudgeEffectFrame.transform);

            effect.GetComponent<Image>().color = _myJudge == GameConstants.Judge.Miss ? ConstantsColors.JUDGE_COLOR[3] : ConstantsColors.BEAM_COLOR;
            
            //エフェクトの表示位置
            effect.GetComponent<RectTransform>().localPosition = new Vector2(gameObject.GetComponent<RectTransform>().localPosition.x, 0);
            effect.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        }
    }
    
}