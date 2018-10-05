using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class ValueSlider:MonoBehaviour
    {
        public GameObject _valueView;

        public void SetValue(int maxValue, int minValue, int initValue)
        {
            var slider = gameObject.GetComponent<Slider>();
            slider.maxValue = maxValue;
            slider.minValue = minValue;
            _SetText( initValue.ToString() );
            

        }
        
        public void OnValueChanged()
        {
            _SetText( gameObject.GetComponent<Slider>().value.ToString() );
        }

        private void _SetText(string value)
        {
            _valueView.GetComponent<Text>().text = value;
        }
    }
}