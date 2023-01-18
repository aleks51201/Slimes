using SlimeEvolutions.Architecture.CrossData;
using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;
using SlimeEvolutions.Timers;
using System;

namespace SlimeEvolutions.Panel.Crossing.CrossTimer
{
    public class TimerLogic : IActivatable
    {
        private TimerView timerView;
        private Timer timer;


        private CrossingSpaceData CrossingSpaceData => Game.GetInteractor<CrossingSpaceInteractor>().CrossingSpaces[timerView.ID];
        private bool IsAvaibleTime => CrossingSpaceData.HasBeenSlimeTaken || CrossingSpaceData.EndTimeCrossing < DateTime.Now;


        public static Action StartedTimerEvent;
        public static Action FinishedTimerEvent;
        

        public TimerLogic(TimerView timerView)
        {
            this.timerView = timerView;
        }


        private void StartTimer()
        {
            if (IsAvaibleTime)
            {
                return;
            }
            float seconds = (float)(CrossingSpaceData.EndTimeCrossing - DateTime.Now).TotalSeconds;
            timer = new(TimerTypes.OneSecTick, seconds);
            UpdateTimerView(seconds);
            TimerSubscribe();
            StartedTimerEvent?.Invoke();
        }

        private void UpdateTimerView(float seconds)
        {
            var time = TimeSpan.FromSeconds(seconds);
            timerView.TimerText.text = $"{time.Minutes}:{time.Seconds}";
        }

        private void StopTimer()
        {
            if (timer is null || !timer.isActive)
            {
                return;
            }
            timer.Stop();
            TimerUnsubscribe();
            FinishedTimerEvent?.Invoke();
        }

        private void TimerSubscribe()
        {
            timer.OnTimerValueChangedEvent += UpdateTimerView;
        }

        private void TimerUnsubscribe()
        {
            timer.OnTimerValueChangedEvent += UpdateTimerView;
        }

        public void OnEnable()
        {
            StartTimer();
        }

        public void OnDisable()
        {
            StopTimer();
        }
    }
}
