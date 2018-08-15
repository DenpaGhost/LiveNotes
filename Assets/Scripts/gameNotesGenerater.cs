using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class gameNotesGenerater : MonoBehaviour {

    private ushort bpm, num, repeat;
	private byte max, min;
	private byte[] Notes;

	// Use this for initialization
	public void Start ()
	{

		bpm = 120;
		max = 1;
		min = 1;
		num = 20;
		repeat = 1;
		
		Notes = new byte[num];

	}
	
	// Update is called once per frame
	public void Update () {

		
		
	}

	void Generate()
	{

		Notes = new byte[num];
		
		for (var i = 0; i < Notes.Length; i++)
		{

			var each = (byte)Random.Range(min,max+1);
			byte[] tmp = {1, 2, 4, 8, 16, 32, 64};
			
			for (var j = 0; j < each; j++)
			{
				var task = (byte) Random.Range(0, 7-j);
				Notes[i] |= tmp[task];
				tmp[task] = tmp[tmp.Length-(j+1)];

			}

		}
	}
	
}
