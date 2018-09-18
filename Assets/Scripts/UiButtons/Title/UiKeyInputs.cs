using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UiKeyInputs : MonoBehaviour
{

    public GameObject QuickButton, DialogNegativeButton;
    public Image ExitDialogImage;
    public Animator CanvasAnimator;
    private bool _isNothingCurrentSelected = true, _enableKeyInput;

	// Use this for initialization
    private void Start () {
        StartCoroutine(StartKeyInput());
	}

    private IEnumerator StartKeyInput() {
        yield return new WaitForSeconds(2.5f);
        _enableKeyInput = true;
    }
	
	// Update is called once per frame
    private void Update () {

        //メニューの上下選択（デフォルト設定だけ）
        if (EventSystem.current.currentSelectedGameObject == null && Input.GetButtonDown("Vertical") && _enableKeyInput
            && !ExitDialogImage.raycastTarget)
        {
            EventSystem.current.SetSelectedGameObject(QuickButton);
        }

        //exitDialogが有効なとき、左右入力があったとき
        if (EventSystem.current.currentSelectedGameObject == null && Input.GetButtonDown("Horizontal") 
            && ExitDialogImage.raycastTarget) {

            EventSystem.current.SetSelectedGameObject(DialogNegativeButton);

        }
        
        //選ばれてるGameObjectがなくなったとき、アニメーションを初期状態に戻す
        if (EventSystem.current.currentSelectedGameObject == null && _isNothingCurrentSelected)
        {
            CanvasAnimator.SetTrigger(UiConstants.DIALOG_IDLE_TRIGGER);
            _isNothingCurrentSelected = false;
        }
        else if(EventSystem.current.currentSelectedGameObject != null)
        {
            _isNothingCurrentSelected = true;
        }

    }

}
