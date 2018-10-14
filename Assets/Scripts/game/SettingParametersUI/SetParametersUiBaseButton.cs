using UnityEngine;

namespace game
{
    public class SetParametersUiBaseButton: MonoBehaviour
    {
        public GameObject Slider;
        public GameObject SettingsCard;
        public virtual void OnClick()
        {
            var instanceSlider = Instantiate(Slider);
            instanceSlider.GetComponent<Transform>().SetParent(SettingsCard.GetComponent<Transform>());
            instanceSlider.GetComponent<RectTransform>().position = 
                new Vector2(
                    gameObject.GetComponent<RectTransform>().position.x, 
                    gameObject.GetComponent<RectTransform>().position.y
                    );

            LiveNotesFunctions.SetCurrentSelect(instanceSlider.GetComponent<Transform>().Find("Slider").gameObject);
        }
    }
}