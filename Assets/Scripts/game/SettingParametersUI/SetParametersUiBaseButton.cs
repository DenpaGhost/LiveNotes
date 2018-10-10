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
                    gameObject.GetComponent<RectTransform>().position.y - 80
                    );

            LiveNotesFunctions.SetCurrentSelect(instanceSlider.GetComponent<Transform>().Find("Handle").gameObject);
        }
    }
}