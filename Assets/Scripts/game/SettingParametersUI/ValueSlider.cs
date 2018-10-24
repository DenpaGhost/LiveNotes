using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace game
{
    public class ValueSlider : MonoBehaviour
    {
        public GameObject _valueView;
        public GameObject slider;
        private GameObject calledButtonObject;
        private bool doesExitPointer;

        public void SetValue(int maxValue, int minValue, int initValue, GameObject button)
        {
            var sliderUI = slider.GetComponent<Slider>();
            sliderUI.maxValue = maxValue;
            sliderUI.minValue = minValue;
            sliderUI.value = initValue;
            calledButtonObject = button;
        }

        public void OnValueChanged()
        {
            _SetText(UtilFunctions.PutComma(slider.GetComponent<Slider>().value));
        }

        private void _SetText(string value)
        {
            _valueView.GetComponent<Text>().text = value;
        }

        public void PointerExit()
        {
            doesExitPointer = true;
        }

        public void PointerEnter()
        {
            doesExitPointer = false;
        }

        private void Update()
        {
            if (doesExitPointer && Input.GetMouseButtonDown(0))
            {
                closeSlider();
            }
        }

        public void positiveButtonClickEvent()
        {
            closeSlider();
        }

        public void negativeButtonClickEvent()
        {
            Destroy(gameObject);
        }
        
        private void closeSlider()
        {
            calledButtonObject.GetComponent<SetParametersUiBaseButton>().onReturnButton(slider.GetComponent<Slider>().value);
            Destroy(gameObject);
        }
    }
}