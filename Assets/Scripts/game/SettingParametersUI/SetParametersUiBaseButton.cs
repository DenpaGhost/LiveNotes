using UnityEngine;
using UnityEngine.UI;

namespace game
{
    public abstract class SetParametersUiBaseButton: MonoBehaviour
    {
        public GameObject SliderTemplate;
        public GameObject SettingsCard;

        protected GameObject SliderInstance;
        
        public virtual void OnClick()
        {
            SliderInstance = Instantiate(SliderTemplate);
            SliderInstance.GetComponent<Transform>().SetParent(SettingsCard.GetComponent<Transform>());
            SliderInstance.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
            SliderInstance.GetComponent<RectTransform>().position = 
                new Vector2(
                    gameObject.GetComponent<RectTransform>().position.x - 20, 
                    gameObject.GetComponent<RectTransform>().position.y
                    );

            LiveNotesFunctions.SetCurrentSelect(SliderInstance.GetComponent<Transform>().Find("Slider").gameObject);
        }

        public virtual void onReturnButton(float value)
        {
            LiveNotesFunctions.SetParametersToView();
            setText(UtilFunctions.PutComma((long)value));
        }

        protected void setText(string text)
        {
            gameObject.GetComponent<Transform>().Find("Text").GetComponent<Text>().text = text;
        }

    }
}