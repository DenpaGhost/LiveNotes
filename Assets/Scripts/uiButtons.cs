using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class uiButtons : MonoBehaviour {

    Animator canvas;
    GameObject audioSource;

    // Use this for initialization
    void Start () {
        canvas = GameObject.Find("Canvas").GetComponent<Animator>();
        audioSource = GameObject.Find("Audio Source");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //マウスカーソルがボタンの上に乗ったとき、選択状態にする
    public void MouseSelector()
    {
        EventSystem.current.SetSelectedGameObject(gameObject);
    }

    //ボタンが選択状態になったとき、アニメーションを再生する
    public void ButtonHighlight()
    {
        audioSource.GetComponent<AudioSource>().Stop();
        audioSource.GetComponent<AudioSource>().PlayOneShot(audioSource.GetComponent<AudioSource>().clip);

        switch (EventSystem.current.currentSelectedGameObject.name)
        {
            case "quickButton":
                canvas.ResetTrigger("artistHighlight");
                canvas.ResetTrigger("settigsHighlight");
                canvas.ResetTrigger("exitHighlight");

                canvas.SetTrigger("quickHighlight");
                break;

            case "artistButton":

                canvas.ResetTrigger("quickHighlight");
                canvas.ResetTrigger("settigsHighlight");
                canvas.ResetTrigger("exitHighlight");

                canvas.SetTrigger("artistHighlight");

                break;

            case "settingsButton":

                canvas.ResetTrigger("quickHighlight");
                canvas.ResetTrigger("artistHighlight");
                canvas.ResetTrigger("exitHighlight");

                canvas.SetTrigger("settigsHighlight");

                break;

            case "exitButton":

                canvas.ResetTrigger("quickHighlight");
                canvas.ResetTrigger("artistHighlight");
                canvas.ResetTrigger("settigsHighlight");

                canvas.SetTrigger("exitHighlight");

                break;

        }
    }

    //ボタンがEnterキーで選択されたとき、Circleの座標をずらさずアニメーションを再生する
    public void ButtonSubmit()
    {
        gameObject.transform.Find("Circle").gameObject.transform.localPosition = new Vector2(0,0);
        gameObject.GetComponent<Animator>().SetTrigger("Submit");
        ClickEvent();
    }

    //ボタンがマウスでクリックされたとき、Circleの座標をずらしてアニメーションを再生する
    public void OnClick()
    {
        gameObject.transform.Find("Circle").gameObject.transform.position = Input.mousePosition;
        gameObject.GetComponent<Animator>().SetTrigger("Submit");
        ClickEvent();
    }

    //クリックイベント
    public void ClickEvent() {

        switch (gameObject.name) {

            case "exitButton":
                EventSystem.current.SetSelectedGameObject(null);
                canvas.SetTrigger("exitDialogShow");

                break;

        }

    }
}
