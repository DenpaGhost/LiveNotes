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

        //スコアのゼロクリア
        public static void ZeroClearScores()
        {
            GameParameters.Perfect = 0;
            GameParameters.Great = 0;
            GameParameters.Good = 0;
            GameParameters.Miss = 0;
            GameParameters.NotesCount = 0;
            SetJudgeCount();
        }

        //左のあっこへ数値を反映する。
        public static void SetJudgeCount(GameConstants.Judge judge)
        {
            switch (judge)
            {
                case GameConstants.Judge.Perfect:
                    GameParameters.PerfectTextView.GetComponent<Text>().text =
                        UtilFunctions.PutComma(GameParameters.Perfect);
                    break;

                case GameConstants.Judge.Great:
                    GameParameters.GreatTextView.GetComponent<Text>().text =
                        UtilFunctions.PutComma(GameParameters.Great);
                    break;

                case GameConstants.Judge.Good:
                    GameParameters.GoodTextView.GetComponent<Text>().text =
                        UtilFunctions.PutComma(GameParameters.Good);
                    break;

                default:
                    GameParameters.MissTextView.GetComponent<Text>().text =
                        UtilFunctions.PutComma(GameParameters.Miss);
                    break;
            }

            GameParameters.ScoreTextView.GetComponent<Text>().text =
                UtilFunctions.PutComma(CalcScore());
        }

        public static void SetJudgeCount()
        {
            GameParameters.PerfectTextView.GetComponent<Text>().text =
                UtilFunctions.PutComma(GameParameters.Perfect);

            GameParameters.GreatTextView.GetComponent<Text>().text =
                UtilFunctions.PutComma(GameParameters.Great);

            GameParameters.GoodTextView.GetComponent<Text>().text =
                UtilFunctions.PutComma(GameParameters.Good);

            GameParameters.MissTextView.GetComponent<Text>().text =
                UtilFunctions.PutComma(GameParameters.Miss);

            GameParameters.ScoreTextView.GetComponent<Text>().text =
                UtilFunctions.PutComma(CalcScore());
        }

        //デバッグ用。判定表示。
        public static void SetJudgeText(GameConstants.Judge judge)
        {
            GameParameters.JudgeTextObject.GetComponent<Text>().text =
                GameConstants.JUDGE_STRINGS[judge.GetHashCode()];
            GameParameters.JudgeTextObject.GetComponent<Text>().color =
                ConstantsColors.JUDGE_COLOR[judge.GetHashCode()];
            GameParameters.JudgeTextObject.GetComponent<JudgeTextManager>().stopwatch.Stop();
            GameParameters.JudgeTextObject.GetComponent<JudgeTextManager>().stopwatch.Reset();
            GameParameters.JudgeTextObject.GetComponent<JudgeTextManager>().stopwatch.Start();
        }
    }
}