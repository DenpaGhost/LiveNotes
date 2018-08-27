using System.Diagnostics;
using Constants;
using UnityEngine;
using Lf = Game.LiveNotesFunctions;

namespace Game
{
	public class Border : MonoBehaviour {

		public long TargetTime { private get; set; }
		public Stopwatch Timer { private get; set; }

		private bool doesCheckListCount = false;
	
		// Update is called once per frame
		private void Update ()
		{
			//描画される位置を計算
			var position = Lf.CalcuSpawnPosition(Timer.ElapsedTicks, TargetTime);
			
			//配置
			gameObject.GetComponent<RectTransform>().localPosition = new Vector2(0, GameConstants.JUDGE_LINE_Y + position);

			if (TargetTime < Timer.ElapsedTicks)
			{
				if (GameParameters.NotesList.Count < GameParameters.MinListCount && !doesCheckListCount)
				{
					GameParameters.NotesList = Lf.PushNotesDataToList(GameParameters.NotesList);
					doesCheckListCount = true;
				}
				
				Destroy(gameObject);
			}
			
		}
	}

}

