using SlimeEvolutions.Architecture;
using SlimeEvolutions.Panel.Crossing.CrossTimer;
using System.Collections;
using UnityEngine;

namespace SlimeEvolutions.Panel.Crossing.Update.Behaviours
{
    public class TimeAvailableBehaviour : IUpdateViewBehaviour
    {
        private UpdateView updateView;
        private bool isSubscribe;

        private UpdateViewBehaviour UpdateViewBehaviour => updateView.UpdateViewBehaviour;


        public void Enter(UpdateView updateView)
        {
            this.updateView = updateView;
            Initialize();
            Subscribe();
            Debug.Log("TimeAvailableBehaviour enter");
        }

        public void Exit()
        {
            Unsubscribe();
        }

        public void OnEnable()
        {
            Subscribe();
            ChangeBehaviour();
        }

        public void OnDisable()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            if (isSubscribe)
            {
                return;
            }
            Coroutines.StartRoutine(TimerSubscribe());
            isSubscribe = true;
        }

        private void Unsubscribe()
        {
            if (!isSubscribe)
            {
                return;
            }
            updateView.Timer.GetComponent<TimerView>().TimerLogic.FinishedTimerEvent -= OnFinishedTimer;
            isSubscribe = false;
        }

        private void Initialize()
        {
            updateView.ButtonSetActive(false);
            updateView.TimerSetActive(true);
            updateView.SliderSetActive(true);
            updateView.InitializedTimeAvailableBehaviourEvent?.Invoke();
        }

        private void ChangeBehaviour()
        {
            UpdateViewBehaviour.SetBehaviourByDefault();
        }

        private void OnFinishedTimer()
        {
            UpdateViewBehaviour.SetTimeIsNotAvailableBehaviour();
        }

        private IEnumerator TimerSubscribe()
        {
            var timerView = updateView.Timer.GetComponent<TimerView>();
            while(timerView.TimerLogic is null)
            {
                yield return null;
            }
            timerView.TimerLogic.FinishedTimerEvent += OnFinishedTimer;
        }
    }
}
