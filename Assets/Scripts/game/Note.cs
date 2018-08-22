using System.Collections;
using System.Collections.Generic;
using game;
using UnityEngine;

public class Note : MonoBehaviour
{

	private ulong _judgeTime;
	private Timer _timer;

	public ulong JudgeTime
	{
		get { return _judgeTime; }
		set { _judgeTime = value; }
	}

	public Timer Timer
	{
		get { return _timer; }
		set { _timer = value; }
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		gameObject.GetComponent<RectTransform>().localPosition = new Vector2(gameObject.GetComponent<RectTransform>().localPosition.x,gameObject.GetComponent<RectTransform>().localPosition.y - 10);

	}
	
}

