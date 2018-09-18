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

        public virtual void Select()
        {
            AudioSource.Stop();
            AudioSource.PlayOneShot(AudioSource.clip);
            
            CanvasAnimator.ResetTrigger(UiConstants.QUICK_HIGHLIGHT_TRIGGER);
            CanvasAnimator.ResetTrigger(UiConstants.ARTIST_HIGHLIGHT_TRIGGER);
            CanvasAnimator.ResetTrigger(UiConstants.SETTING_HIGHLIGHT_TRIGGER);
            CanvasAnimator.ResetTrigger(UiConstants.EXIT_HIGHLIGHT_TRIGGER);

        }

        public abstract void ClickEvent();
    }
}