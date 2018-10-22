using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using UnityEngine;

namespace game
{
    public class NotesOperator : MonoBehaviour
    {
        //リストをいっぱいにするための関数
        public static void PushNotesDataToList(List<NotesData> list, BaseComposer composer)
        {
            //オフセット
            long offset;
            if (list.Count == 0)
            {
                offset = GameConstants.DEFAULT_OFFSET;
            }
            else
            {
                //画面に残っているノーツの数を取得
                var drawNotesCount = GameObject.FindGameObjectsWithTag("Border").Length;

                //まだリストに残ってる分 + 画面内にいる分
                offset = (list.Count + drawNotesCount) * GameParameters.Interval;
            }

            //それぞれのノーツが参照するタイマーの設定
            var timer = new Stopwatch();
            timer.Start();

            //targetTimeをずらすためのカウンタ
            var counter = 0;

            //超えるまで作る
            while (list.Count <= GameParameters.MinListCount)
            {
                var phrase =
                    composer.GeneratePhrase(GameParameters.PhraseLength, GameParameters.Max, GameParameters.Min);

                for (var repeat = 0; repeat < GameParameters.RefreshRate; repeat++)
                {
                    foreach (var note in phrase)
                    {
                        var targetTime = GameParameters.Interval * counter + offset;
                        list.Add(new NotesData(note, targetTime, timer));
                        counter++;
                    }
                }
            }
        }


        //ノーツ生成時の初期位置を計算する関数
        public static float CalcSpawnPosition(long nowTime, long targetTime)
        {
            var y = (targetTime - nowTime) / 100000f * GameParameters.Speed;

            return y;
        }

        //キューを読み出してGameObjectを生成する関数
        public static void SpawnNote(List<NotesData> notesList, GameObject notesArea, GameObject noteWide,
            GameObject noteSmall, GameObject noteBorder)
        {
            while (true)
            {
                //値を受け取る
                var targetTime = notesList[0].TargetTime;
                var timer = notesList[0].Timer;

                //描画されるであろう位置を計算
                var spawnPosition = CalcSpawnPosition(timer.ElapsedTicks, targetTime);

                //画面外でなければ描画
                if (GameConstants.NOTES_AREA_HEIGHT > spawnPosition)
                {
                    //ボーダー生成
                    var border = Instantiate(noteBorder);
                    border.GetComponent<Border>().TargetTime = targetTime;
                    border.GetComponent<Border>().Timer = timer;
                    border.GetComponent<Transform>().SetParent(notesArea.GetComponent<Transform>());
                    border.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    border.GetComponent<RectTransform>().localPosition = new Vector2(
                        border.GetComponent<RectTransform>().localPosition.x,
                        GameConstants.JUDGE_LINE_Y + spawnPosition);
                    border.GetComponent<RectTransform>().offsetMin = noteBorder.GetComponent<RectTransform>().offsetMin;
                    border.GetComponent<RectTransform>().offsetMax = noteBorder.GetComponent<RectTransform>().offsetMax;

                    var lanesPosition = notesList[0].LanesPosition;

                    for (var i = 0; i < GameConstants.POSITION_DATA.Length; i++)
                    {
                        if ((lanesPosition & GameConstants.POSITION_DATA[i]) == GameConstants.POSITION_DATA[i])
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

                            //ノーツ生成
                            note.transform.SetParent(notesArea.GetComponent<Transform>());
                            note.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                            note.GetComponent<RectTransform>().localPosition = new Vector2(
                                GameConstants.LANE_POSITION_DATA_X[i], GameConstants.JUDGE_LINE_Y + spawnPosition);
                            note.GetComponent<Note>().TargetTime = targetTime;
                            note.GetComponent<Note>().Timer = timer;
                            note.GetComponent<Note>().Lane = i;

                            //キューに追加
                            GameParameters.LaneQueue[i].Add(note);
                        }
                    }

                    //先頭を削除
                    notesList.RemoveAt(0);
                }
                else
                {
                    return;
                }
            }
        }
    }
}