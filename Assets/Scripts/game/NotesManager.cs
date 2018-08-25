using System.Collections.Generic;
using System.Diagnostics;
using Constants;
using UnityEngine;
using Lf = Game.LiveNotesFunctions;

namespace Game
{
    public class NotesManager : MonoBehaviour
    {

        private Stopwatch _sw;

        private List<NotesData> _notesList;

        public GameObject _notesArea, _noteSmall, _noteWide;

        // Use this for initialization
        public void Start()
        {
            // パラメータ代入 TODO:デバッグ用
            GameParameters.Bpm = 120;
            GameParameters.Max = 1;
            GameParameters.Min = 1;
            GameParameters.Num = 20;
            GameParameters.Repeat = 1;
            GameParameters.Speed = 1;
            
            //Stopwatchのインスタンス生成
            _sw = new Stopwatch();
            
            //刻み数計算
            GameParameters.Interval = 600000000 / GameParameters.Bpm;

            //Listに詰めこむ
            _notesList = Lf.FirstPushNotesDataToList();
            
            
            
            //最初のノーツを出す
            while(true)
            {
                //値を受け取る
                var targetTime = _notesList[0].TargetTime;
                
                //描画されるであろう位置を計算
                var spawnPosition = Lf.CalcuSpawnPosition(0, targetTime);
                
                //画面外でなければ描画
                if (GameConstants.NOTES_AREA_HEIGHT > spawnPosition)
                {
                    var position = _notesList[0].Position;

                    for (int i = 0; i < GameConstants.POSITION_DATA.Length; i++)
                    {
                        if ((position | GameConstants.POSITION_DATA[i]) == GameConstants.POSITION_DATA[i])
                        {
                            GameObject note;
                            if (i % 2 != 0)
                            {
                                note = Instantiate(_noteWide);
                            }
                            else
                            {
                                note = Instantiate(_noteSmall);
                            }
                            
                            note.transform.SetParent(_notesArea.GetComponent<Transform>());
                            note.GetComponent<RectTransform>().localPosition = new Vector2(GameConstants.LANE_POSITION_DATA_X[i], GameConstants.DISPLAY_UPPER_END_Y);
                            note.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                            
                        }
                    }
                    
                }
                else
                {
                    break;
                }

            } 

            
            
            _sw.Start();
        }

        // Update is called once per frame
        public void Update()
        {
            

        }

    }
}