﻿using SlimeEvolutions.Panel.Crossing.CrossTimer;

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
        }

        public void Exit()
        {
            Unsubscribe();
        }

        public void OnEnable()
        {
            Subscribe();
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
            TimerLogic.FinishedTimerEvent += ChangeBehaviour;
            isSubscribe = true;
        }

        private void Unsubscribe()
        {
            if (!isSubscribe)
            {
                return;
            }
            TimerLogic.FinishedTimerEvent -= ChangeBehaviour;
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
            UpdateViewBehaviour.SetMainBehaviour();
        }
    }
}
