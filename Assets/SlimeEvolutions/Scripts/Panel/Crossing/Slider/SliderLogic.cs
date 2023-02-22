using SlimeEvolutions.Architecture;
using SlimeEvolutions.Architecture.CrossData;
using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace SlimeEvolutions.Panel.Crossing.CrossSlider
{
    public class SliderLogic : IActivatable
    {
        private SliderView sliderView;
        private Coroutine currentCoroutine;


        private int ID => sliderView.GetComponentInParent<HoldCrossingPlaceView>().ID;
        private CrossingSpaceData CrossingSpaceData => Game.GetInteractor<CrossingSpaceInteractor>().CrossingSpaces[ID];


        public SliderLogic(SliderView sliderView)
        {
            this.sliderView = sliderView;
        }


        private IEnumerator FillValue(float value)
        {
            var estimateTime = 0f;
            var slider = sliderView.GetComponent<Slider>();
            var sec = (float)(CrossingSpaceData.EndTimeCrossing - DateTime.Now).TotalSeconds;

            var totalSecondsToEnd = CrossingSpaceData.EndTimeCrossing;
            var totalSecondsToStart = CrossingSpaceData.StartTimeCrossing;
            var totalSeconds = (float)(totalSecondsToEnd - totalSecondsToStart).TotalSeconds;
            var totalSecondsDateTimeNow = (float)totalSeconds - (CrossingSpaceData.EndTimeCrossing - DateTime.Now).TotalSeconds;
            var startValue = (float)(totalSecondsDateTimeNow / totalSeconds);

            while (estimateTime < sec)
            {
                estimateTime += Time.deltaTime;
                slider.value = Mathf.Lerp(startValue, value, estimateTime / sec);
                yield return null;
            }
        }

        public void OnEnable()
        {
            currentCoroutine = Coroutines.StartRoutine(FillValue(1));
        }

        public void OnDisable()
        {
            Coroutines.StopRoutine(currentCoroutine);
        }
    }
}
