using System;
using UnityEngine;
using UnityEngine.UI;

namespace game
{
    public class ValueSlider:MonoBehaviour
    {
        public GameObject _valueView;
        public GameObject slider;
        private SetParametersUiBaseButton calledButtonClass;

        public void SetValue(int maxValue, int minValue, int initValue,SetParametersUiBaseButton button)
        {
            var sliderUI = slider.GetComponent<Slider>();
            sliderUI.maxValue = maxValue;
            sliderUI.minValue = minValue;
            sliderUI.value = initValue;
            calledButtonClass = button;
        }
        
        public void OnValueChanged()
        {
            _SetText( slider.GetComponent<Slider>().value.ToString() );
        }

        private void _SetText(string value)
        {
            _valueView.GetComponent<Text>().text = value;
        }

        public void Deselect()
        {
            calledButtonClass.onReturnButton(slider.GetComponent<Slider>().value);
            Destroy(gameObject);
        }
    }
}