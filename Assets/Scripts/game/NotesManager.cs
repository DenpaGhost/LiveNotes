using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesManager : MonoBehaviour {

	private gameParameters _parameters;
	private byte[] Notes;

	// Use this for initialization
	public void Start ()
	{
		_parameters = new gameParameters();
		
		_parameters.Bpm = 120;
		_parameters.Max = 1;
		_parameters.Min = 1;
		_parameters.Num = 20;
		_parameters.Repeat = 1;
		
		Notes = new byte[_parameters.Num];

	}
	
	// Update is called once per frame
	public void Update () {

		
		
	}
	
}
