using UnityEngine;

namespace Game
{
    public class SetParametersUiBaseButton: MonoBehaviour
    {
        public GameObject Slider;
        public GameObject SettingsCard;
        public void OnClick()
        {
            var instanceSlider = Instantiate(Slider);
            instanceSlider.GetComponent<Transform>().SetParent(SettingsCard.GetComponent<Transform>());
            instanceSlider.GetComponent<RectTransform>().position = 
                new Vector2(gameObject.GetComponent<RectTransform>().position.x, 
                    gameObject.GetComponent<RectTransform>().position.y - 80);
        }
    }
}