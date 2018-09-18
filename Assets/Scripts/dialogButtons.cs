using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dialogButtons : MonoBehaviour {

    GameObject canvas,audioSource;

	// Use this for initialization
	public void Start () {
        canvas = GameObject.Find("Canvas");
        audioSource = GameObject.Find("Audio Source");
    }
	
	// Update is called once per frame
	public void Update () {
		
	}

    public void MouseEnter()
    {
        EventSystem.current.SetSelectedGameObject(gameObject);
    }

    public void ButtonClick()
    {
        gameObject.transform.Find("Circle").gameObject.transform.position = Input.mousePosition;
        gameObject.GetComponent<Animator>().SetTrigger("Submit");
        OnClick();
    }

    public void ButtonPressed()
    {
        gameObject.transform.Find("Circle").gameObject.transform.localPosition = new Vector2(0, 0);
        gameObject.GetComponent<Animator>().SetTrigger("Submit");
        OnClick();
    }

    public void Selected()
    {
        audioSource.GetComponent<AudioSource>().Stop();
        audioSource.GetComponent<AudioSource>().PlayOneShot(audioSource.GetComponent<AudioSource>().clip);
        gameObject.GetComponent<Animator>().SetTrigger("Selected");
    }

    public void Normal()
    {
        gameObject.GetComponent<Animator>().SetTrigger("Deselected");
    }

    public void OnClick()
    {
        switch (gameObject.name)
        {
            case "positiveButton":
                Application.Quit();
                break;


            case "negativeButton":

                canvas.GetComponent<Animator>().SetTrigger("exitDialogClose");
                EventSystem.current.SetSelectedGameObject(null);

                break;
            
        }
    }
}
