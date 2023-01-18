﻿using SlimeEvolutions.Panel.Crossing.CrossTimer;
using SlimeEvolutions.Timers;
using System;

namespace SlimeEvolutions.Panel.Crossing.Update.Behaviours
{
    public class TimeAvailableBehaviour : IUpdateViewBehaviour
    {
        private UpdateView updateView;
        private bool isSubscribe;
        private Timer timer;

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
            StartTimer();
            updateView.ButtonSetActive(false);
            updateView.TimerSetActive(true);
            updateView.SliderSetActive(true);
            updateView.InitializedTimeAvailableBehaviourEvent?.Invoke();
        }

        private void ChangeBehaviour()
        {
            UpdateViewBehaviour.SetMainBehaviour();
        }

        private void StartTimer()
        {
            float seconds =(float) (updateView.CrossingSpaceData.EndTimeCrossing - DateTime.Now).TotalSeconds;
            timer = new Timer(TimerTypes.OneSecTick,seconds);
            timer.Start();
        }

        public void TimerSubscribe()
        {
            timer.OnTimerFinishedEvent += ChangeBehaviour;
        }

        public void TimerUnsubscribe()
        {
            timer.OnTimerFinishedEvent -= ChangeBehaviour;
        }
    }
}
