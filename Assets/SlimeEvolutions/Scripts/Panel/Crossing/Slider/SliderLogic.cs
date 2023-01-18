using SlimeEvolutions.Architecture.CrossData;
using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;
using SlimeEvolutions.Timers;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace SlimeEvolutions.Panel.Crossing.CrossSlider
{
    public class SliderLogic : IActivatable
    {
        private SliderView sliderView;
        private Timer timer;


        private int ID => sliderView.GetComponentInParent<HoldCrossingPlaceView>().ID;
        private CrossingSpaceData CrossingSpaceData => Game.GetInteractor<CrossingSpaceInteractor>().CrossingSpaces[ID];


        public SliderLogic(SliderView sliderView)
        {
            this.sliderView = sliderView;
        }


        private void StartFillingIn()
        {
            float seconds = (float)(CrossingSpaceData.EndTimeCrossing - DateTime.Now).TotalSeconds;
            timer = new Timer(TimerTypes.UpdateTick, seconds);
            timer.Start();
        }

        private void UpdateSliderView(float secons)
        {
            var slider = sliderView.GetComponent<Slider>();
            slider.value = Mathf.Lerp(0, 1, secons);
        }

        private void TimerSubscribe()
        {
            timer.OnTimerValueChangedEvent += UpdateSliderView;
        }

        private void TimerUnsubscribe()
        {
            timer.OnTimerValueChangedEvent -= UpdateSliderView;
        }

        public void OnEnable()
        {
            StartFillingIn();
        }

        public void OnDisable()
        {
        }
    }
}
