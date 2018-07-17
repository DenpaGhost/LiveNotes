using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class uiKeyInputs : MonoBehaviour {

    bool flag = true,enableKeyInput = false;

	// Use this for initialization
	void Start () {
        StartCoroutine(StartKeyInput());
	}

    IEnumerator StartKeyInput() {
        yield return new WaitForSeconds(2.5f);
        enableKeyInput = true;
    }
	
	// Update is called once per frame
	void Update () {

        //メニューの上下選択（デフォルト設定だけ）
        if (EventSystem.current.currentSelectedGameObject == null && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) && enableKeyInput && !GameObject.Find("exitDialog").GetComponent<Image>().raycastTarget)
        {
            EventSystem.current.SetSelectedGameObject(GameObject.Find("quickButton"));
        }

        //exitDialogが有効なとき、左右入力があったとき
        if (EventSystem.current.currentSelectedGameObject == null && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) 
            && GameObject.Find("exitDialog").GetComponent<Image>().raycastTarget) {

            EventSystem.current.SetSelectedGameObject(GameObject.Find("negativeButton"));

        }
        
        //選ばれてるGameObjectがなくなったとき、アニメーションを初期状態に戻す
        if (EventSystem.current.currentSelectedGameObject == null && flag)
        {
            GameObject.Find("Canvas").GetComponent<Animator>().SetTrigger("idle");
            flag = false;
        }
        else if(EventSystem.current.currentSelectedGameObject != null)
        {
            flag = true;
        }

    }

}
