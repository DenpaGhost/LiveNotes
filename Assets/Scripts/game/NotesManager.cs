using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using game;
using UnityEngine;

public class NotesManager : MonoBehaviour {

	private gameParameters _parameters;
	private byte[] Notes;
	private double _interval;
	private LiveNotesFunctions _functions;
	private Stopwatch sw;
	
	public GameObject _notesArea,_noteSmall,_noteWide;

	// Use this for initialization
	public void Start ()
	{
		//数値共有用オブジェクトのインスタンス生成
		_parameters = new gameParameters
		{
			Bpm = 120,
			Max = 1,
			Min = 1,
			Num = 20,
			Repeat = 1
		};

		//関数クラスのインスタンス生成
		_functions = new LiveNotesFunctions();
		
		//配列確保
		Notes = new byte[_parameters.Num];
		
		//刻み秒数計算
		_interval = 1000 / _parameters.Bpm;
		
		sw = new Stopwatch();
		sw.Start();
	}
	
	// Update is called once per frame
	public void Update ()
	{
		if (sw.ElapsedMilliseconds > 1000)
		{
			var note = Instantiate(_noteSmall);
			note.transform.parent = _notesArea.transform;
			note.GetComponent<RectTransform>().localPosition = new Vector2(0, 390);
			note.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
			sw.Stop();sw.Reset();sw.Start();
		}


	}
	
}
