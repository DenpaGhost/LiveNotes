using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameNotesGenerater : MonoBehaviour {

    private uint bpm, max, min, num, repeat;
	private uint[] Notes;

	// Use this for initialization
	void Start ()
	{

		bpm = 120;
		max = 1;
		min = 1;
		num = 20;
		repeat = 1;
		
		Notes = new uint[num];

	}
	
	// Update is called once per frame
	void Update () {


		
	}

	void Generate()
	{
		for (var i = 0; i < Notes.Length; i++)
		{

			var each = (short)Random.Range(min,max+1);

			for (var j = 0; j < each; j++)
			{
				uint[] tmp = {1, 2, 4, 8, 16, 32, 64};
			}

		}
	}
	
}
