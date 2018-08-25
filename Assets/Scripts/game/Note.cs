using System.Diagnostics;
using UnityEngine;

namespace Game
{
	public class Note : MonoBehaviour
	{
		public long TargetTime { get; set; }
		public Stopwatch Timer { get; set; }

		void Start () {
			
		}
	
		// Update is called once per frame
		void Update ()
		{
		
			//gameObject.GetComponent<RectTransform>().localPosition = new Vector2(gameObject.GetComponent<RectTransform>().localPosition.x,gameObject.GetComponent<RectTransform>().localPosition.y - 10);

		}
	
	}
}

