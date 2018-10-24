using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAfter500ms : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		StartCoroutine(bye());
	}
	
	IEnumerator  bye()
	{
		yield return new WaitForSeconds(0.5f);
		Destroy(gameObject);
	}
}
