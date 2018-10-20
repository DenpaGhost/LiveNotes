using System;
using UnityEngine.UI;

namespace game
{
    public class ScoreOperator
    {
        //スコア計算関数
        public static ulong CalcScore()
        {
            return GameParameters.Perfect * GameConstants.SCORE_PERFECT +
                   GameParameters.Great * GameConstants.SCORE_GREAT +
                   GameParameters.Good * GameConstants.SCORE_GOOD;
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
                    GameParameters.GoodTextView.GetComponent<Text>().text =
                        String.Format("{0:#,0}", GameParameters.Good);
                    break;

                default:
                    GameParameters.MissTextView.GetComponent<Text>().text =
                        String.Format("{0:#,0}", GameParameters.Miss);
                    break;
            }

            var score = CalcScore();
            GameParameters.ScoreTextView.GetComponent<Text>().text = String.Format("{0:#,0}", score);
        }
        
        //デバッグ用。判定表示。
        public static void SetJudgeText(string text)
        {
            GameParameters.JudgeTextObject.GetComponent<Text>().text = text;
            GameParameters.JudgeTextObject.GetComponent<JudgeTextManager>().stopwatch.Stop();
            GameParameters.JudgeTextObject.GetComponent<JudgeTextManager>().stopwatch.Reset();
            GameParameters.JudgeTextObject.GetComponent<JudgeTextManager>().stopwatch.Start();
        }
    }
}