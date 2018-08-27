using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;
using UnityEngine.Experimental.UIElements;
using Image = UnityEngine.UI.Image;

public class GameKeyManager : MonoBehaviour
{

	public GameObject keyA, keyAs, keyB, keyBs, keyC, keyCs, keyD;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		KeyDownEvents();
		KeyUpEvent();

	}

	private void KeyDownEvents()
	{
		//A鍵
		if (Input.GetKeyDown(KeyCode.S))
		{
			keyA.GetComponent<Image>().color = ConstantsColors.KEY_COLOR_WHITE_PUSH;
		}
		
		//A#鍵
		if (Input.GetKeyDown(KeyCode.D))
		{
			keyAs.GetComponent<Image>().color = ConstantsColors.KEY_COLOR_BLACK_PUSH;
		}
		
		//B鍵
		if (Input.GetKeyDown(KeyCode.F))
		{
			keyB.GetComponent<Image>().color = ConstantsColors.KEY_COLOR_WHITE_PUSH;
		}
		
		//B#鍵
		if (Input.GetKeyDown(KeyCode.Space))
		{
			keyBs.GetComponent<Image>().color = ConstantsColors.KEY_COLOR_BLACK_PUSH;
		}
		
		//C鍵
		if (Input.GetKeyDown(KeyCode.J))
		{
			keyC.GetComponent<Image>().color = ConstantsColors.KEY_COLOR_WHITE_PUSH;
		}
		
		//C#鍵
		if (Input.GetKeyDown(KeyCode.K))
		{
			keyCs.GetComponent<Image>().color = ConstantsColors.KEY_COLOR_BLACK_PUSH;
		}
		
		//D鍵
		if (Input.GetKeyDown(KeyCode.L))
		{
			keyD.GetComponent<Image>().color = ConstantsColors.KEY_COLOR_WHITE_PUSH;
		}
	}

	private void KeyUpEvent()
	{
		//A鍵
		if (Input.GetKeyUp(KeyCode.S))
		{
			keyA.GetComponent<Image>().color = ConstantsColors.KEY_COLOR_WHITE;
		}
		
		//A#鍵
		if (Input.GetKeyUp(KeyCode.D))
		{
			keyAs.GetComponent<Image>().color = ConstantsColors.KEY_COLOR_BLACK;
		}
		
		//B鍵
		if (Input.GetKeyUp(KeyCode.F))
		{
			keyB.GetComponent<Image>().color = ConstantsColors.KEY_COLOR_WHITE;
		}
		
		//B#鍵
		if (Input.GetKeyUp(KeyCode.Space))
		{
			keyBs.GetComponent<Image>().color = ConstantsColors.KEY_COLOR_BLACK;
		}
		
		//C鍵
		if (Input.GetKeyUp(KeyCode.J))
		{
			keyC.GetComponent<Image>().color = ConstantsColors.KEY_COLOR_WHITE;
		}
		
		//C#鍵
		if (Input.GetKeyUp(KeyCode.K))
		{
			keyCs.GetComponent<Image>().color = ConstantsColors.KEY_COLOR_BLACK;
		}
		
		//D鍵
		if (Input.GetKeyUp(KeyCode.L))
		{
			keyD.GetComponent<Image>().color = ConstantsColors.KEY_COLOR_WHITE;
		}
	}
}
