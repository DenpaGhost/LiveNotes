using System.Collections;
using UnityEngine;

namespace game
{
    public class SetParametersUiBaseButton: MonoBehaviour
    {
        public GameObject SliderTemplate;
        public GameObject SettingsCard;

        protected GameObject SliderInstance;
        
        public virtual void OnClick()
        {
            SliderInstance = Instantiate(SliderTemplate);
            SliderInstance.GetComponent<Transform>().SetParent(SettingsCard.GetComponent<Transform>());
            SliderInstance.GetComponent<RectTransform>().position = 
                new Vector2(
                    gameObject.GetComponent<RectTransform>().position.x, 
                    gameObject.GetComponent<RectTransform>().position.y
                    );

            LiveNotesFunctions.SetCurrentSelect(SliderInstance.GetComponent<Transform>().Find("Slider").gameObject);
        }

        public virtual void setParameter(ushort value)
        {
            
        }

    }
}