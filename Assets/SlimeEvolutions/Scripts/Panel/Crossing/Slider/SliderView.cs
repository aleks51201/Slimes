using UnityEngine;

namespace SlimeEvolutions.Panel.Crossing.CrossSlider
{
    public class SliderView : MonoBehaviour
    {
        private SliderLogic sliderLogic;


        private void Awake()
        {
            sliderLogic = new(this);
        }

        private void OnEnable()
        {
            sliderLogic.OnEnable();
        }

        private void OnDisable()
        {
            sliderLogic.OnDisable();
        }
    }
}
