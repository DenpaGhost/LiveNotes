using System.Diagnostics;
using UnityEngine;

namespace game
{
	public class Border : MonoBehaviour {

		public long TargetTime { private get; set; }
		public Stopwatch Timer { private get; set; }
		public AudioClip soundClick;

		private bool doesCheckListCount = false;
	
		// Update is called once per frame
		private void Update ()
		{
			//描画される位置を計算
			var position = NotesOperator.CalcSpawnPosition(Timer.ElapsedTicks, TargetTime);
			
			//配置
			gameObject.GetComponent<RectTransform>().localPosition = new Vector2(0, GameConstants.JUDGE_LINE_Y + position);

			//目標の時間になったら...
			if (TargetTime <= Timer.ElapsedTicks)
			{
				//リスト項目数を確認
				if (GameParameters.NotesList.Count < GameParameters.MinListCount && !doesCheckListCount)
				{
					//必要数を下回ってたら生成
					GameParameters.NotesList = NotesOperator.PushNotesDataToList(GameParameters.NotesList, ComposerPlain.GetInstance());
					doesCheckListCount = true;
				}
				
				GameParameters.JudgeLineSpeaker.Stop();
				GameParameters.JudgeLineSpeaker.PlayOneShot(soundClick);
				Destroy(gameObject);
			}
			
		}
		
	}
}

