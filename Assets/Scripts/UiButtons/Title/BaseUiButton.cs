using UnityEngine;
using UnityEngine.EventSystems;

namespace UiButtons.Title
{
    public abstract class BaseUiButton : MonoBehaviour
    {
        public Animator CanvasAnimator;
        public AudioSource AudioSource;
        public GameObject Circle;
        
        public void PointerEnter()
        {
            EventSystem.current.SetSelectedGameObject(gameObject);
        }

        //ボタンがEnterキーで選択されたとき、Circleの座標をずらさずアニメーションを再生する
        public void Submit()
        {
            Circle.transform.localPosition = new Vector2(0,0);
            gameObject.GetComponent<Animator>().SetTrigger(UiConstants.SUBMIT_TRIGGER);
            
            ClickEvent();
        }

        //ボタンがマウスでクリックされたとき、Circleの座標をずらしてアニメーションを再生する
        public void PointerClick()
        {
            Circle.transform.position = Input.mousePosition;
            gameObject.GetComponent<Animator>().SetTrigger(UiConstants.SUBMIT_TRIGGER);
            
            ClickEvent();
        }

        public abstract void Select();

        public abstract void ClickEvent();
    }
}