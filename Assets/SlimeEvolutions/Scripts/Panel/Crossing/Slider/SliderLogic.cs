using SlimeEvolutions.Architecture;
using SlimeEvolutions.Architecture.CrossData;
using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;
using SlimeEvolutions.Timers;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace SlimeEvolutions.Panel.Crossing.CrossSlider
{
    public class SliderLogic : IActivatable
    {
        private SliderView sliderView;
        private Timer timer;
        private float num;
        private bool flag;


        private int ID => sliderView.GetComponentInParent<HoldCrossingPlaceView>().ID;
        private CrossingSpaceData CrossingSpaceData => Game.GetInteractor<CrossingSpaceInteractor>().CrossingSpaces[ID];


        public SliderLogic(SliderView sliderView)
        {
            this.sliderView = sliderView;
        }


        private void StartFillingIn()
        {
            float seconds = (float)(CrossingSpaceData.EndTimeCrossing - DateTime.Now).TotalSeconds;
            timer = new Timer(TimerTypes.OneSecTick, seconds);
            timer.Start();
            TimerSubscribe();
        }

        float seconds;
        private void UpdateSliderView(float secons)
        {
            var slider = sliderView.GetComponent<Slider>();
            //Debug.Log(secons+"sec") ;
            //Debug.Log(Mathf.Lerp(0, 1,Time.deltaTime * secons)+"lerp");
            num += Time.deltaTime;
            if (flag)
            {
                seconds = secons;
            }

            slider.value = Mathf.Lerp(0, 1, num / seconds);
        }

        private IEnumerator FillValue(float value)
        {
            var estimateTime = 0f;
            var slider = sliderView.GetComponent<Slider>();
            var sec =(float) (CrossingSpaceData.EndTimeCrossing - DateTime.Now).TotalSeconds;

            while (estimateTime < sec)
            {
                estimateTime += Time.deltaTime;
                Debug.Log(estimateTime);
                slider.value = Mathf.Lerp(0, value, estimateTime / sec);
                yield return null;
            }
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
            num = 0;
            flag = true;
            seconds = 0;

            Coroutines.StartRoutine(FillValue(1));
        }

        public void OnDisable()
        {
        }
    }
}
