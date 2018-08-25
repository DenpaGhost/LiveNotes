using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Constants;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Lf = Game.LiveNotesFunctions;

namespace Game
{
    public class NotesManager : MonoBehaviour
    {

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
                
                Debug.Log(spawnPosition);
                
                //画面外でなければ描画
                if (GameConstants.NOTES_AREA_HEIGHT > spawnPosition)
                {
                    var lanesPosition = _notesList[0].LanesPosition;

                    for (int i = 0; i < GameConstants.POSITION_DATA.Length; i++)
                    {
                        if ((lanesPosition | GameConstants.POSITION_DATA[i]) == GameConstants.POSITION_DATA[i])
                        {
                            GameObject note;
                            if (i % 2 == 0)
                            {
                                note = Instantiate(_noteWide);
                            }
                            else
                            {
                                note = Instantiate(_noteSmall);
                            }
                            
                            note.transform.SetParent(_notesArea.GetComponent<Transform>());
                            note.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                            note.GetComponent<RectTransform>().localPosition = new Vector2(GameConstants.LANE_POSITION_DATA_X[i], GameConstants.DISPLAY_UPPER_END_Y - spawnPosition);

                            note.GetComponent<Note>().TargetTime = targetTime;
                            

                            //先頭を削除
                            _notesList.RemoveAt(0);
                        }
                    }
                    
                }
                else
                {
                    break;
                }

            } 

        }

        // Update is called once per frame
        public void Update()
        {
            

        }

    }
}