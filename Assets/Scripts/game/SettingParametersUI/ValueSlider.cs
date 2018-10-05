using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class ValueSlider:MonoBehaviour
    {
        public GameObject _valueView;
        
        public void OnValueChanged()
        {
            _valueView.GetComponent<Text>().text = gameObject.GetComponent<Slider>().value.ToString();
        }
    }
}